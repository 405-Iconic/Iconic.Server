using AutoMapper;
using Iconic.Domain.Entities.Quizes;
using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Entitites.Discussions;
using Iconic.Domain.Entitites.Forums;
using Iconic.Domain.Entitites.Users;
using Iconic.Service.DTOs.Courses;
using Iconic.Service.DTOs.Discussions;
using Iconic.Service.DTOs.Forums;
using Iconic.Service.DTOs.Quizzes;
using Iconic.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<AttachmentForCreationDto, Attachment>().ReverseMap();
            CreateMap<CategoryForCreationDto, Category>().ReverseMap();
            CreateMap<CategoryForViewDto, Category>().ReverseMap();
            CreateMap<CourseForCreationDto, Course>().ReverseMap();
            CreateMap<CourseForViewDto, Course>().ReverseMap(); 
            CreateMap<LessonForCreationDto, Lesson>().ReverseMap();
            CreateMap<LessonForViewDto,  Lesson>().ReverseMap();
            CreateMap<LessonTaskForCreationDto, LessonTask>().ReverseMap();

            //discussion
            CreateMap<ChatForCreationDto, Chat>().ReverseMap();
            CreateMap<MessageForCreationDto, Message>().ReverseMap();
            CreateMap<ForumAnswerForCreationDto, ForumAnswer>().ReverseMap();
            CreateMap<ForumQuestionForCreationDto, ForumQuestion>().ReverseMap();
            
            //quiz
            CreateMap<AnswerForCreationDto, Answer>().ReverseMap();
            CreateMap<QuestionForCreationDto, Question>().ReverseMap();
            CreateMap<QuizForCreationDto, Quiz>().ReverseMap();
            CreateMap<QuizResultForCreationDto, Quiz>().ReverseMap();
            CreateMap<SolvedQuestionForCreationDTO, SolvedQuestion>().ReverseMap();
            
            //user
            CreateMap<TeacherForCreationDto, Teacher>().ReverseMap();
            CreateMap<TeacherForViewDto, Teacher>().ReverseMap();
            CreateMap<UserForCreationDto, User>().ReverseMap();
            CreateMap<UserForViewDto, User>().ReverseMap();

        }
    }
}
