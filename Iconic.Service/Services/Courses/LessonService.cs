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
    public class LessonService : ILessonService
    {
        private readonly IGenericRepository<Lesson> lessonRepository;
        private readonly IGenericRepository<Course> courseRepository;
        private readonly IAttachmentService attachmentService;
        private readonly IMapper mapper;
        public LessonService(IGenericRepository<Lesson> lessonRepository,
            IGenericRepository<Course> courseRepository,
            IAttachmentService attachmentService,
            IMapper mapper)
        {
            this.lessonRepository = lessonRepository;
            this.courseRepository = courseRepository;
            this.attachmentService = attachmentService;
            this.mapper = mapper;
        }
        public async Task<LessonForViewDto> CreateAsync(LessonForCreationDto dto)
        {
            var existCourse = await courseRepository.GetAsync(c => c.Id == dto.CourseId);

            if (existCourse == null)
                throw new HttpStatusCodeException(404,"course not found");

            int? attachmentId = null;
            if (dto.File != null)
            {
                var attachment = await attachmentService.UploadImageAsync(dto.File);
                attachmentId = attachment.Id;
            }

            var lesson = mapper.Map<Lesson>(dto);
            lesson.AttachmentId = attachmentId;

            var createdLesson = await lessonRepository.AddAsync(lesson);
            
            await lessonRepository.SaveChangesAsync();

            return mapper.Map<LessonForViewDto>(createdLesson);
        }

        public async Task<bool> DeleteAsync(Expression<Func<Lesson, bool>> expression)
        {
            var existLesson = await lessonRepository.GetAsync(expression);

            if (existLesson == null)
                throw new HttpStatusCodeException(404, "Lesson not found");

            lessonRepository.Delete(existLesson);
            await lessonRepository.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<LessonForViewDto>> GetAllAsync(PaginationParams @params,
            Expression<Func<Lesson, bool>> expression,
            string search = null)
        {
            var lessons = await lessonRepository.GetAll(expression)
                .ToPagedList(@params)
                .ToListAsync();

            var result = !string.IsNullOrEmpty(search) ?
                lessons.Where(c => c.Title.Contains(search) || c.Documentation.Contains(search)).ToList()
                : lessons.ToList();
            return mapper.Map<List<LessonForViewDto>>(result);
        }

        public async Task<LessonForViewDto> GetAsync(Expression<Func<Lesson, bool>> expression)
        {
            var existLesson = await lessonRepository.GetAsync(expression);
            if (existLesson == null)
                throw new HttpStatusCodeException(404,"Lesson not found");

            return mapper.Map<LessonForViewDto>(existLesson);
        }

        public async Task<LessonForViewDto> UpdateAsync(int id, LessonForCreationDto dto)
        {
            var existLesson = await lessonRepository.GetAsync(l => l.Id == id);
            if (existLesson == null)
                throw new HttpStatusCodeException(404, "Lesson not found");

            var res = lessonRepository.Update(mapper.Map(dto, existLesson));
            await lessonRepository.SaveChangesAsync();

            return mapper.Map<LessonForViewDto>(res);
        }
    }
}
