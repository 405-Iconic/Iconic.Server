using Iconic.Data.IRepositories;
using Iconic.Data.Repositories;
using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Entitites.News;
using Iconic.Service.Interfaces.Courses;
using Iconic.Service.Interfaces.News;
using Iconic.Service.Services.Courses;
using Iconic.Service.Services.News;
using Microsoft.Extensions.DependencyInjection;

namespace Iconic.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            //repositories
            services.AddScoped<IGenericRepository<Gallery>, GenericRepository<Gallery>>();
            services.AddScoped<IGenericRepository<New>, GenericRepository<New>>();
            services.AddScoped<IGenericRepository<Attachment>, GenericRepository<Attachment>>();
            //services
            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<INewsService, NewService>();
            services.AddScoped<IAttachmentService, AttachmentService>();
        }
    }
}
