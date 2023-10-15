using Iconic.Domain.Configurations;
using Iconic.Service.DTOs.News;
using Iconic.Service.Extensions;
using Iconic.Service.Interfaces.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Iconic.Api.Controllers
{
    public class GalleryController : BaseApiController
    {
        private readonly IGalleryService galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            this.galleryService = galleryService;
        }

        [HttpPost("{newsId}"), Authorize(Roles = "Admin")]
        public async ValueTask<IActionResult> CreateAsync([FromRoute] long newsId, IFormFile formFile)
        {
            var dto = new GalleryForCreationDto()
            {
                Attachment = formFile.ToAttachmentOrDefault(),
                NewsId = newsId
            };
            return Ok(await galleryService.CreateAsync(dto));
        }

        [HttpPut("{id}/{newsId}"), Authorize(Roles = "Admin")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] long id, [FromRoute] long newsId, IFormFile formFile)
        {
            var dto = new GalleryForCreationDto()
            {
                Attachment = formFile.ToAttachmentOrDefault(),
                NewsId = newsId
            };

            return Ok(await galleryService.UpdateAsync(id, dto));
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] long id)
            => Ok(await galleryService.DeleteAsync(id));

        [HttpGet]
        public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params)
            => Ok(await galleryService.GetAll(@params));

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] long id)
            => Ok(await galleryService.GetAsync(c => c.Id == id));

        [HttpPost("range/{newsId}"), Authorize(Roles = "Admin")]
        public async ValueTask<IActionResult> AddRangeAsync([FromRoute] int newsId, IFormFile[] formFiles)
            => Ok(await galleryService.AddRange(newsId, formFiles));
    }
}
