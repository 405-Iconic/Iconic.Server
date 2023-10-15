using Iconic.Domain.Configurations;
using Iconic.Service.DTOs.News;
using Iconic.Service.Interfaces.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Iconic.Api.Controllers
{
    public class NewsController : BaseApiController
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async ValueTask<IActionResult> CreateAsync([FromForm] NewForCreationDto dto)
        {
            return Ok(await newsService.CreateAsync(dto));
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] long id, [FromForm] NewForCreationDto dto)
        {
            return Ok(await newsService.UpdateAsync(id, dto));

        }
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] long id)
            => Ok(await newsService.DeleteAsync(id));

        [HttpGet]
        public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params)
            => Ok(await newsService.GetAll(@params));

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] long id)
            => Ok(await newsService.GetAsync(c => c.Id == id));
    }
}
