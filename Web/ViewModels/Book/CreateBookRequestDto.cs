using System;
using Infrastructure.Services.Ebook;

namespace Web.ViewModels.Book
{
    public class CreateBookRequestDto
    {
        public Guid UploadId { get; set; }
        public EBookType Type { get; set; }
    }
}
