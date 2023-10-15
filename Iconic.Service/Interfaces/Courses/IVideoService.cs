using Iconic.Domain.Configurations;
using Iconic.Domain.Entitites.Courses;
using Iconic.Service.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Interfaces.Courses
{
    public interface IVideoService
    {
        ValueTask<VideoForViewDto> CreateAsync(string link, int id);
        ValueTask<ICollection<VideoForViewDto>> CreateRangeAsync(string youtubePlaylist, int courseId, int? courseModuleId = null);
        ValueTask<bool> DeleteAsync(int youtubeId);
        ValueTask<bool> DeleteRangeAsync(int courseId);
        ValueTask<ICollection<VideoForViewDto>> UpdateRangeAsync(string youtubePlaylist, int courseId, int courseModuleId);
        ValueTask<VideoForViewDto> UpdateAsync(int videoId, string link);
        ValueTask<VideoForViewDto> GetAsync(Expression<Func<Video, bool>> expression);
        ValueTask<IEnumerable<VideoForViewDto>> GetAllAsync(PaginationParams @params,
            Expression<Func<VideoForViewDto, bool>> expression = null);
        ValueTask<IEnumerable<string>> GetLinksAsync(string playlistLink);
    }
}
