using AutoMapper;
using Iconic.Data.IRepositories;
using Iconic.Domain.Configurations;
using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Entitites.News;
using Iconic.Service.DTOs.Courses;
using Iconic.Service.DTOs.News;
using Iconic.Service.Exceptions;
using Iconic.Service.Extensions;
using Iconic.Service.Interfaces.Courses;
using Iconic.Service.Interfaces.News;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Services.News
{
    public class NewService : INewsService
    {
        private readonly IGenericRepository<New> newRepository;
        private readonly IAttachmentService attachmentService;
        private readonly IGenericRepository<Gallery> repository;
        private readonly IMapper mapper;

        public NewService(IGenericRepository<New> genericRepository, IGenericRepository<Gallery> repository, IAttachmentService attachmentService, IMapper mapper)
        {
            this.newRepository = genericRepository;
            this.repository = repository;
            this.attachmentService = attachmentService;
            this.mapper = mapper;
        }

        public async Task<NewForViewDto> CreateAsync(NewForCreationDto newForCreationDto)
        {
            var attachmet = await attachmentService.UploadImageAsync(newForCreationDto.BannerForm.ToAttachmentOrDefault());

            var createdNew = await newRepository.AddAsync(mapper.Map<New>(newForCreationDto));

            createdNew.BannerId = attachmet.Id;

            await newRepository.SaveChangesAsync();

            return mapper.Map<NewForViewDto>(createdNew);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var existNew = await newRepository.GetAsync(n => n.Id == id);

            if (existNew == null)
                throw new HttpStatusCodeException(404, "News not found");

            newRepository.Delete(existNew);
            await newRepository.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<NewForViewDto>> GetAll(PaginationParams @params, Expression<Func<New, bool>> expression = null)
        {
            var @new = await newRepository.GetAll(expression)
                .ToPagedList(@params)
                .ToListAsync();

            return mapper.Map<IEnumerable<NewForViewDto>>(@new);
        }

        public async Task<NewForViewDto> GetAsync(Expression<Func<New, bool>> expression)
        {
            var @new = await newRepository.GetAsync(expression);
            if (@new == null)
                throw new HttpStatusCodeException(404, "News not found");
            return mapper.Map<NewForViewDto>(@new);
        }

        public async Task<NewForViewDto> UpdateAsync(long id, NewForCreationDto newForCreationDto)
        {
            var existNews = await newRepository.GetAsync(c => c.Id == id);

            if (existNews is null)
                throw new HttpStatusCodeException(404, "News not found");

            var attachmet = await attachmentService.UpdateAsync(existNews.BannerId, newForCreationDto.BannerForm.ToAttachmentOrDefault().Stream);

            var updatedGallery = newRepository.Update(mapper.Map(newForCreationDto, existNews));
            await newRepository.SaveChangesAsync();

            return mapper.Map<NewForViewDto>(updatedGallery);
        }
    }
}
