using AutoMapper;
using Iconic.Data.IRepositories;
using Iconic.Domain.Configurations;
using Iconic.Domain.Entitites.Courses;
using Iconic.Service.DTOs.Courses;
using Iconic.Service.Exceptions;
using Iconic.Service.Extensions;
using Iconic.Service.Interfaces.Courses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Services.Courses
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> categoryRepository;
        private readonly IMapper mapper;
        public CategoryService(IGenericRepository<Category> categoryRepository,IMapper mapper) 
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<CategoryForViewDto> CreateAsync(CategoryForCreationDto dto)
        {
            var existCategory = await categoryRepository.GetAsync(c => c.Title == dto.Title);
            if (existCategory != null)
                throw new HttpStatusCodeException(400,"This category already exist");

            var newCategory = await categoryRepository.AddAsync(mapper.Map<Category>(dto));

            await categoryRepository.SaveChangesAsync();
            
            return mapper.Map<CategoryForViewDto>(newCategory);
        }

        public async Task<bool> DeleteAsync(Expression<Func<Category, bool>> expression)
        {
            var existCategory = await categoryRepository.GetAsync(expression);
            if (existCategory == null)
                throw new HttpStatusCodeException(404,"Category not found");
            
            categoryRepository.Delete(existCategory);
            await categoryRepository.SaveChangesAsync();
            
            return true;
        }

        public async Task<IEnumerable<CategoryForViewDto>> GetAllAsync(PaginationParams @params, Expression<Func<Category, bool>> expression = null)
        {
            var categories = await categoryRepository.GetAll(expression)
                .ToPagedList(@params)
                .ToListAsync();

            return mapper.Map<List<CategoryForViewDto>>(categories);
        }

        public async Task<CategoryForViewDto> GetAsync(Expression<Func<Category, bool>> expression)
        {
            var category = await categoryRepository.GetAsync(expression);
            if (category == null)
                throw new HttpStatusCodeException(404, "Category not found");

            return mapper.Map<CategoryForViewDto>(category);
        }

        public async Task<CategoryForViewDto> UpdateAsync(int id, CategoryForCreationDto dto)
        {
            var existCategory = await categoryRepository.GetAsync(c => c.Id == id);
            if (existCategory == null)
                throw new HttpStatusCodeException(404,"Category not found");

            var result = categoryRepository.Update(mapper.Map(dto,existCategory));

            await categoryRepository.SaveChangesAsync();

            return mapper.Map<CategoryForViewDto>(existCategory);
        }
    }
}
