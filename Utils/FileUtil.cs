using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class FileUtil
    {
        public static async Task<string> GenerateFileAsync(string folderPath, IFormFile formFile)
        {
            var fileName = $"{Guid.NewGuid()}-{formFile.FileName}";
            var filePath = Path.Combine(folderPath, fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            }

            return fileName;
        }

        public static async Task<string> GenerateFileAsync(List<string> folderPaths, IFormFile formFile)
        {
            var fileName = $"{Guid.NewGuid()}-{formFile.FileName}";
            var filePath = "";
            foreach (var folderPath in folderPaths)
            {
                filePath = Path.Combine(folderPath, fileName);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }
            }


            return fileName;
        }
    }
}
