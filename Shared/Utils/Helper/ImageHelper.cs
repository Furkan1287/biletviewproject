using Microsoft.AspNetCore.Http;
using Shared.Utils.Result;

namespace Shared.Utils.Helper
{
    public static class ImageHelper
    {
        readonly static string directory = Environment.CurrentDirectory + @"\wwwroot";
        static string path = @"\images\";
        public static string AddImage(IFormFile file, Guid imageId)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var extension = Path.GetExtension(file.FileName);
            var newFileName = imageId.ToString("N") + extension;

            File.Move(sourcepath, directory + path + newFileName);
            return (path + newFileName).Replace("\\", "/");
        }
        public static ICommandResult DeleteImage(string oldPath)
        {
            path = (directory + oldPath).Replace("/", "\\");
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorCommandResult(exception.Message);
            }
            return new SuccessCommandResult();
        }
    }
}
