namespace AllAboutGames.Common
{
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public static class GlobalMethods
    {
        public static async Task<string> UploadedFile(IFormFile image, string gameName, string rootPath, string mainFile)
        {
            var fileName = Path.GetFileName(image.FileName);
            var directory = $"{rootPath}\\images\\{mainFile}\\{gameName}";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{rootPath}\\images\\{mainFile}\\{gameName}", fileName);

            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileSteam);
            }

            return $"\\images\\{mainFile}\\{gameName}\\{fileName}";
        }
    }
}
