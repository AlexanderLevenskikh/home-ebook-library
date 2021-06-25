using System;
using Web.ViewModels.Shared;

namespace Web.ViewModels.Upload
{
    public class UploadDto : Dto<Guid>
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
    }
}