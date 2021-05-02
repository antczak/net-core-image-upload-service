using ImageUpload.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUpload.Services
{
    public interface IUploadManager
    {
        public Task<int> UploadFileAsync(IFormFile file, User user);
    }
}
