using System.IO;

namespace Iconic.Service.Helpers;

public class EnvironmentHelper
{
    public static string WebRootPath { get; set; }
    private static string Image => "images";
    private static string Resume => "resumes";
    public static string ResumePath => Path.Combine(WebRootPath, Image);
    public static string ImagePath => Path.Combine(WebRootPath, Resume);

}
