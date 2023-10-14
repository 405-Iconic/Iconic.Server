
using Iconic.Service.DTOs.Courses;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Iconic.Service.Helpers;

public class FileHelper
{
    /// <summary>
    /// This function for saving images to the wwwroot file asynchronously
    /// </summary>
    /// <param name="file"><see cref="AttachmentForCreationDTO"/></param>
    /// <returns>return saved file name end this file static path</returns>
    public static async Task<(string fileName, string filePath)> SaveImageAsync(AttachmentForCreationDto file, bool isExist = false)
    {
        // genarate file destination
        string fileName = isExist ? file.FileName : Guid.NewGuid().ToString("N") + "-" + file.FileName;
        string filePath = Path.Combine(EnvironmentHelper.ImagePath, fileName);

        // copy image to the destination as stream
        FileStream fileStream = File.OpenWrite(filePath);
        await file.Stream.CopyToAsync(fileStream);

        // clear
        await fileStream.FlushAsync();
        fileStream.Close();

        return (fileName, EnvironmentHelper.ImagePath + "/" + fileName);
    }
    /// <summary>
    /// This function for saving resumes to the wwwroot file asynchronously
    /// </summary>
    /// <param name="file"></param>
    /// <param name="isExist"></param>
    /// <returns>return saved file name end this file static path</returns>
    public static async Task<(string fileName, string filePath)> SaveResumeAsync(AttachmentForCreationDto file, bool isExist = false)
    {
        // genarate file destination
        string fileName = isExist ? file.FileName : Guid.NewGuid().ToString("N") + "-" + file.FileName;
        string filePath = Path.Combine(EnvironmentHelper.ResumePath, fileName);

        // copy image to the destination as stream
        FileStream fileStream = File.OpenWrite(filePath);
        await file.Stream.CopyToAsync(fileStream);

        // clear
        await fileStream.FlushAsync();
        fileStream.Close();

        return (fileName, EnvironmentHelper.ResumePath + "/" + fileName);
    }

    /// <summary>
    /// This function for remove file from wwwroot by given static path which is given by function parametr
    /// </summary>
    /// <param name="staticPath">file static path</param>
    /// <returns>if file is exists and deleted successfully return true else false</returns>
    public static bool Remove(string staticPath)
    {
        string fullPath = Path.Combine(EnvironmentHelper.WebRootPath, staticPath);

        if (!File.Exists(fullPath))
            return false;

        File.Delete(fullPath);
        return true;
    }
}