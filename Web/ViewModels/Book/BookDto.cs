using System;
using Web.ViewModels.Shared;

namespace Web.ViewModels.Book
{
    public class BookDto : Dto<Guid>
    {
        public string Title { get; set; }
        public Guid ContentId { get; set; }
        public Guid? ImageId { get; set; }
    }
}
