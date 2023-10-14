using AutoMapper;
using Iconic.Data.IRepositories;
using Iconic.Domain.Entitites.Courses;
using Iconic.Service.DTOs.Courses;
using Iconic.Service.Exceptions;
using Iconic.Service.Interfaces.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Services.Courses
{
    public class LessonTaskService : ILessonTaskService
    {
        private readonly IGenericRepository<LessonTask> lessonTaskRepository;
        private readonly IAttachmentService attachmentService;
        private readonly IMapper mapper;

        public LessonTaskService(IGenericRepository<LessonTask> lessonTaskRepository)
        {
            this.lessonTaskRepository = lessonTaskRepository;
        }

        public async Task<LessonTaskForViewDto> CreateAsync(LessonTaskForCreationDto dto)
        {
            int? attachmentId = null;
            if (dto.File != null)
            {
                var attachment = await attachmentService.UploadImageAsync(dto.File);
                attachmentId = attachment.Id;
            }

            var lessonTask = mapper.Map<LessonTask>(dto); 
            lessonTask.AttachmentId = attachmentId;

            var createdLessonTask = await lessonTaskRepository.AddAsync(lessonTask);
            await lessonTaskRepository.SaveChangesAsync();

            return mapper.Map<LessonTaskForViewDto>(createdLessonTask);
        }

        public async Task<bool> DeleteAsync(Expression<Func<LessonTask, bool>> expression)
        {
            var lessonTask = await lessonTaskRepository.GetAsync(expression);

            if (lessonTask == null)
                throw new HttpStatusCodeException(404,"Lesson Task not found");

            lessonTaskRepository.Delete(lessonTask);
            await lessonTaskRepository.SaveChangesAsync();

            return true;
        }

        public Task<IEnumerable<LessonTaskForViewDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LessonTaskForViewDto> GetAsync(Expression<Func<LessonTask, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<LessonTaskForViewDto> UpdateAsync(int id, LessonTaskForCreationDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
