using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utilities
{
    public static class UploadImage
    {
        public static async Task<string> SaveImage(IFormFile img, string folder)
        {
            string fullPath = Path.Combine(Path.GetFullPath("wwwroot"), "uploads", folder);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            string fileName = Guid.NewGuid().ToString() + img.FileName;
            string filePath = Path.Combine(fullPath, fileName);

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await img.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}
