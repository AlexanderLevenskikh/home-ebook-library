using System;
using Web.ViewModels.Shared;

namespace Web.ViewModels.Upload
{
    public class UploadDto : Dto<Guid>
    {
        public string Name { get; set; } = default!;
        public string ContentType { get; set; } = default!;
        public long Size { get; set; }
    }
}