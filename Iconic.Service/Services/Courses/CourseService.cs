using AutoMapper;
using Iconic.Data.IRepositories;
using Iconic.Domain.Configurations;
using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Entitites.Users;
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
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Course> courseRepository;
        private readonly IGenericRepository<Teacher> teacherRepository;
        private IAttachmentService attachmentService;
        private readonly IMapper mapper;

        public CourseService(IGenericRepository<Course> courseRepository,
            IGenericRepository<Teacher> teacherRepository,
            IMapper mapper)
        {
            this.courseRepository = courseRepository;
            this.teacherRepository = teacherRepository;
            this.mapper = mapper;
        }

        public async Task<CourseForViewDto> CreateAsync(CourseForCreationDto dto)
        {
            var existTeacher = await teacherRepository.GetAsync(t => t.Id == dto.TeacherId);
            
            if (existTeacher == null)
                throw new HttpStatusCodeException(404,"Course not found");
            int? attachmentId = null;
            if (dto.File != null)
            {
                var attachment = await attachmentService.UploadImageAsync(dto.File);
                attachmentId = attachment.Id;
            }

            var course = mapper.Map<Course>(dto);
            course.ImageId = attachmentId;

            var createdCourse = await courseRepository.AddAsync(course);
            await courseRepository.SaveChangesAsync();

            return mapper.Map<CourseForViewDto>(createdCourse);
        }

        public async Task<bool> DeleteAsync(Expression<Func<Course, bool>> expression)
        {
            Course course = await courseRepository.GetAsync(expression: expression, "Image");

            if (course is null)
                throw new HttpStatusCodeException(404, "Course not found");

            courseRepository.Delete(entity: course);

            if (course.ImageId is not null)
            {
                await this.attachmentService.DeleteAsync(a => a.Id == course.Image.Id);
                return true;
            }

            await this.courseRepository.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CourseForViewDto>> GetAllAsync(PaginationParams @params,
            Expression<Func<Course, bool>> expression,
            string search = null)
        {
            IQueryable<Course> pagedList = courseRepository.GetAll(
                expression: expression,
                includes: "Teacher,Category,Image",
                isTracking: false)
                .ToPagedList(@params);

            var result = !string.IsNullOrEmpty(search) ? 
                await pagedList.Where(c => c.Title == search || c.Description.Contains(search)).ToListAsync()
                : await pagedList.ToListAsync();
            return mapper.Map<List<CourseForViewDto>>(result);
        }

        public async Task<CourseForViewDto> GetAsync(Expression<Func<Course, bool>> expression)
        {
            Course course = await courseRepository.GetAsync(
                expression: expression,
                includes: "Image,Lessons");

            if (course is null)
                throw new HttpStatusCodeException(404, "Course not found");

            var courseView = mapper.Map<CourseForViewDto>(course);
            await courseRepository.SaveChangesAsync();

            return courseView;
        }

        public async Task<CourseForViewDto> UpdateAsync(int id, CourseForCreationDto dto)
        {
            Course course = await courseRepository.GetAsync(c => c.Id == id);

            if (course is null)
                throw new HttpStatusCodeException(404, "Course not found");

            long? attachmentId = null;
            if (dto.File is not null)
            {
                var attachment = await attachmentService.UpdateAsync(course.Id, dto.File.Stream);
                attachmentId = attachment.Id;
            }
            course = mapper.Map(dto, course);

            course.ImageId = (int)attachmentId;

            course = courseRepository.Update(entity: course);

            return mapper.Map<CourseForViewDto>(course);
        }
    }
}
