using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Web.ViewModels.Upload
{
    public class UploadFileRequestDto
    {
        public IFormFile File { get; set; }
        public UploadProvider Provider { get; set; }
    }
}