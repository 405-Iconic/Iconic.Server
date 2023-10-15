using Iconic.Domain.Configurations;
using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Entitites.News;
using Iconic.Service.DTOs.News;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Interfaces.News
{
    public interface IGalleryService
    {
        Task<GalleryForViewDto> CreateAsync(GalleryForCreationDto galleryForCreationDTO);
        Task<GalleryForViewDto> UpdateAsync(long id, GalleryForCreationDto galleryForCreationDTO);
        Task<IEnumerable<GalleryForViewDto>> GetAll(PaginationParams @params, Expression<Func<Gallery, bool>> expression = null);
        Task<GalleryForViewDto> GetAsync(Expression<Func<Gallery, bool>> expression);
        Task<bool> DeleteAsync(long id);
        Task<bool> AddRange(int newId, IFormFile[] formFiles);
    }
}
