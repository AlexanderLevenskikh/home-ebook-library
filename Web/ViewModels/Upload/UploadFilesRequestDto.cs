using System;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Web.ViewModels.Upload
{
    public class UploadFilesRequestDto
    {
        public IFormFile[] Files { get; set; } = Array.Empty<IFormFile>();
        public UploadProvider Provider { get; set; }
    }
}