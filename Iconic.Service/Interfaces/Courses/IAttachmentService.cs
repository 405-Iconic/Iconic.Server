using Iconic.Domain.Entitites.Courses;
using Iconic.Service.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Interfaces.Courses
{
    public interface IAttachmentService
    {
        ValueTask<Attachment> UploadImageAsync(AttachmentForCreationDto dto);
        ValueTask<Attachment> UploadResumeAsync(AttachmentForCreationDto dto);
        ValueTask<Attachment> UpdateAsync(long id, Stream stream);
        ValueTask<bool> DeleteAsync(Expression<Func<Attachment, bool>> expression);
        ValueTask<Attachment> GetAsync(Expression<Func<Attachment, bool>> expression);
        ValueTask<Attachment> CreateAsync(string fileName, string filePath);
    }
}
