using AutoMapper;
using Iconic.Data.IRepositories;
using Iconic.Domain.Configurations;
using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Entitites.Users;
using Iconic.Service.DTOs.Users;
using Iconic.Service.Exceptions;
using Iconic.Service.Extensions;
using Iconic.Service.Interfaces.Courses;
using Iconic.Service.Services.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Iconic.Service.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> userRepository;
        private readonly IAttachmentService attachmentService;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        public UserService(IGenericRepository<User> userRepository, IConfiguration configuration, IAttachmentService attachmentService)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
            this.attachmentService = attachmentService;
        }

        public async Task<UserForViewDto> CreateAsync(UserForCreationDto userDto)
        {
            var existUser = await userRepository.GetAsync(u => u.Email == userDto.Email);
            if (existUser != null)
                throw new HttpStatusCodeException(400,"User with such email exist");

            int? attachmentId = null;
            if (userDto.File != null)
            {
                var attachment = await attachmentService.UploadImageAsync(userDto.File);
                attachmentId = attachment.Id;
            }
            var user = mapper.Map<User>(userDto);

            user.ImageId = attachmentId;

            var createdUser = await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();
            return mapper.Map<UserForViewDto>(createdUser);
        }

        public string CreateToken(string key, string issuer, User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims, signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public async Task<bool> DeleteAsync(Expression<Func<User, bool>> predicate)
        {
            var existUser = await userRepository.GetAsync(predicate);
            
            if (existUser == null)
                throw new HttpStatusCodeException(404,"User not found");

            userRepository.Delete(existUser);
            await userRepository.SaveChangesAsync();

            return true;
        }

        public async Task<List<UserForViewDto>> GetAll(PaginationParams @params, Expression<Func<User, bool>> predicate = null)
        {
            var users = await userRepository.GetAll(predicate,"Image")
                .ToPagedList(@params)
                .ToListAsync();

            return mapper.Map<List<UserForViewDto>>(users);
        }

        public async Task<UserForViewDto> GetAsync(Expression<Func<User, bool>> predicate)
        {
            var user = await userRepository.GetAsync(predicate)
            ?? throw new HttpStatusCodeException(400, "User not found");

            return mapper.Map<UserForViewDto>(user);
        }

        public async Task<object> LoginAsync(string email, string password)
        {
            var user = await userRepository.GetAsync(p => p.Email == email)
            ?? throw new HttpStatusCodeException(400, "User not found");

            if (password.Encrypt() != user.Password)
                throw new HttpStatusCodeException(200, "Email or password is wrong");

            var token = CreateToken(configuration["Jwt:Key"], configuration["Jwt:Issuer"], user);

            return new 
            {
                Token = token
            };
        }

        public async Task<UserForViewDto> UpdateAsync(int id, UserForCreationDto userDto)
        {
            var existUser = await userRepository.GetAsync(u => u.Id == id);

            if (existUser == null)
                throw new HttpStatusCodeException(404,"User not found");
            existUser = await userRepository.GetAsync(u => u.Email == userDto.Email && u.Id != id);
            if (existUser != null)
                throw new HttpStatusCodeException(400, "User with such email exist");

            int? attachmentId = null;
            if (userDto.File is not null)
            {
                var attachment = await attachmentService.UpdateAsync((int)existUser.ImageId, userDto.File.Stream);
                attachmentId = attachment.Id;
            }
            var user = mapper.Map(userDto, existUser);

            user.ImageId = (int)attachmentId;

            user = mapper.Map(userDto, existUser);
            userRepository.Update(user);
            await userRepository.SaveChangesAsync();

            return mapper.Map<UserForViewDto>(user);
        }
    }
}
