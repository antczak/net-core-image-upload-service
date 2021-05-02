using ImageUpload.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUpload.Services
{
    public class UploadManager : IUploadManager
    {
        private readonly ApplicationDbContext _context;
        public UploadManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> UploadFileAsync(IFormFile file, User user)
        {
            var type = GetMimeType(file.FileName);
            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                var fileBytes = ms.ToArray();
                var image = new Image { Data = fileBytes, MimeType = type, User = user, Date = DateTime.Now };
                _context.Images.Add(image);
                await _context.SaveChangesAsync();
                return image.Id;
            }
        }

        private string GetMimeType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType = "application/octet-stream";
            provider.TryGetContentType(fileName, out contentType);
            return contentType;
        }
    }
}
