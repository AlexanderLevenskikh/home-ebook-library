using System;

namespace Web.ViewModels.Book
{
    public class GetBooksRequestDto : PagingDto
    {
        public Guid? AuthorId { get; set; }
        public string TitleSubstring { get; set; } 
    }
}
