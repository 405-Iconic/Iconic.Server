using Iconic.Data.IRepositories;
using Iconic.Domain.Entitites.Courses;
using Iconic.Service.DTOs.Courses;
using Iconic.Service.Exceptions;
using Iconic.Service.Helpers;
using Iconic.Service.Interfaces.Courses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Service.Services.Courses
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IGenericRepository<Attachment> _repository;

        public AttachmentService(IGenericRepository<Attachment> repository)
        {
            _repository = repository;
        }

        public async ValueTask<Attachment> CreateAsync(string fileName, string filePath)
        {
            var file = new Attachment()
            {
                Name = fileName,
                Path = filePath
            };

            file = await _repository.AddAsync(file);
            await _repository.SaveChangesAsync();

            return file;
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<Attachment, bool>> expression)
        {
            var file = await _repository.GetAsync(expression);

            if (file is null)
                throw new HttpStatusCodeException(404, "Attachment not found");

            // delete file from wwwroot
            string fullPath = Path.Combine(EnvironmentHelper.WebRootPath, file.Path);

            if (File.Exists(fullPath))
                File.Delete(fullPath);

            // datele database information
            FileHelper.Remove(file.Path);

            _repository.Delete(file);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async ValueTask<Attachment> UploadImageAsync(AttachmentForCreationDto dto)
        {
            // genarate file destination
            string fileName = Guid.NewGuid().ToString("N") + "-" + dto.FileName;
            string filePath = Path.Combine(EnvironmentHelper.ImagePath, fileName);

            if (!Directory.Exists(EnvironmentHelper.ImagePath))
                Directory.CreateDirectory(EnvironmentHelper.ImagePath);

            // copy image to the destination as stream
            FileStream fileStream = File.OpenWrite(filePath);
            await dto.Stream.CopyToAsync(fileStream);

            // clear
            await fileStream.FlushAsync();
            fileStream.Close();

            return await CreateAsync(fileName, Path.Combine(EnvironmentHelper.ImagePath, fileName));
        }
        public async ValueTask<Attachment> UploadResumeAsync(AttachmentForCreationDto dto)
        {
            // genarate file destination
            string fileName = Guid.NewGuid().ToString("N") + "-" + dto.FileName;
            string filePath = Path.Combine(EnvironmentHelper.ResumePath, fileName);

            if (!Directory.Exists(EnvironmentHelper.ResumePath))
                Directory.CreateDirectory(EnvironmentHelper.ResumePath);

            // copy image to the destination as stream
            FileStream fileStream = File.OpenWrite(filePath);
            await dto.Stream.CopyToAsync(fileStream);

            // clear
            await fileStream.FlushAsync();
            fileStream.Close();

            return await CreateAsync(fileName, Path.Combine(EnvironmentHelper.ResumePath, fileName));
        }

        public async ValueTask<Attachment> GetAsync(Expression<Func<Attachment, bool>> expression)
        {
            var existAttachement = await _repository.GetAsync(expression);

            if (existAttachement is null)
                throw new HttpStatusCodeException(404, "Attachment not found.");

            return existAttachement;
        }

        public async ValueTask<Attachment> UpdateAsync(long id, Stream stream)
        {
            var existAttachment = await _repository.GetAsync(a => a.Id == id, null);

            if (existAttachment is null)
                throw new HttpStatusCodeException(404, "Attachment not found.");

            string fileName = existAttachment.Path;
            string filePath = Path.Combine(EnvironmentHelper.WebRootPath, fileName);

            // copy image to the destination as stream
            FileStream fileStream = File.OpenWrite(filePath);
            await stream.CopyToAsync(fileStream);

            // clear
            await fileStream.FlushAsync();
            fileStream.Close();

            await _repository.SaveChangesAsync();

            return existAttachment;
        }
    }
}
