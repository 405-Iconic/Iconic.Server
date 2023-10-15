using AutoMapper;
using Iconic.Data.IRepositories;
using Iconic.Domain.Configurations;
using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Entitites.News;
using Iconic.Service.DTOs.News;
using Iconic.Service.Exceptions;
using Iconic.Service.Extensions;
using Iconic.Service.Interfaces.Courses;
using Iconic.Service.Interfaces.News;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Services.News
{
    public class GalleryService : IGalleryService
    {
        private readonly IGenericRepository<Gallery> galleryRepository;
        private readonly IAttachmentService attachmentService;
        private readonly IMapper mapper;

        public GalleryService(IGenericRepository<Gallery> galleryRepository, IMapper mapper, IAttachmentService attachmentService)
        {
            this.galleryRepository = galleryRepository;
            this.mapper = mapper;
            this.attachmentService = attachmentService;
        }

        public async Task<GalleryForViewDto> CreateAsync(GalleryForCreationDto galleryForCreationDTO)
        {
            var attachmet = await attachmentService.UploadImageAsync(galleryForCreationDTO.Attachment);


            var existNews = await galleryRepository.GetAsync(a => a.Id == galleryForCreationDTO.NewsId);

            if (existNews == null)
                throw new HttpStatusCodeException(404, "News not found");

            var createdGallery = await galleryRepository.AddAsync(mapper.Map<Gallery>(galleryForCreationDTO));
            createdGallery.AttachmentId = attachmet.Id;

            await galleryRepository.SaveChangesAsync();

            return mapper.Map<GalleryForViewDto>(createdGallery);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var existGallery = await galleryRepository.GetAsync(n => n.Id == id);

            if (existGallery == null)
                throw new HttpStatusCodeException(404, "News not found");

            galleryRepository.Delete(existGallery);
            await galleryRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<GalleryForViewDto>> GetAll(PaginationParams @params, Expression<Func<Gallery, bool>> expression = null)
        {
            var galllery = await galleryRepository.GetAll(expression)
                .ToPagedList(@params)
                .ToListAsync();

            return mapper.Map<IEnumerable<GalleryForViewDto>>(galllery);
        }

        public async Task<GalleryForViewDto> GetAsync(Expression<Func<Gallery, bool>> expression)
        {
            var gallery = await galleryRepository.GetAsync(expression);
                if (gallery == null)
                throw new HttpStatusCodeException(404, "News not found");
            return mapper.Map<GalleryForViewDto>(gallery);
        }

        public async Task<GalleryForViewDto> UpdateAsync(long id, GalleryForCreationDto galleryForCreationDto)
        {
            var existGallery = await galleryRepository.GetAsync(c => c.Id == id);

            if (existGallery is null)
                throw new HttpStatusCodeException(404, "News not found");

            var attachmet = await attachmentService.UpdateAsync(existGallery.AttachmentId, galleryForCreationDto.Attachment.Stream);

            var updatedGallery = galleryRepository.Update(mapper.Map(galleryForCreationDto, existGallery));
            await galleryRepository.SaveChangesAsync();

            return mapper.Map<GalleryForViewDto>(updatedGallery);
        }

        public async Task<bool> AddRange(int newId, IFormFile[] formFiles)
        {
            var existNews = await galleryRepository.GetAsync(a => a.Id == newId);

            if (existNews == null)
                throw new HttpStatusCodeException(404, "News not found");

            foreach (var i in formFiles)
            {
                var attachmet = await attachmentService.UploadImageAsync(i.ToAttachmentOrDefault());

                var gallery = new Gallery()
                {
                    NewsId = newId,
                    AttachmentId = attachmet.Id
                };
                var createdGallery = await galleryRepository.AddAsync(gallery);

            }
            await galleryRepository.SaveChangesAsync();

            return true;
        }

    }
}
