using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.ImageService
{
    public class ImageService : IImageService
    {
        private readonly string _localStoragePath;

        public ImageService(IConfiguration configuration, IWebHostEnvironment environment)
        {
            // You can configure the path in appsettings.json or use the ContentRootPath
            _localStoragePath = Path.Combine(environment.ContentRootPath, "Local_Storage");
        }

        public async Task SaveImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file.");

            if (!Directory.Exists(_localStoragePath))
            {
                Directory.CreateDirectory(_localStoragePath);
            }

            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_localStoragePath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}