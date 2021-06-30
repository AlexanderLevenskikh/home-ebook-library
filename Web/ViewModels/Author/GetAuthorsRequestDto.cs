using System;

namespace Web.ViewModels.Author
{
    public class GetAuthorsRequestDto : PagingDto
    {
        public Guid? BookId { get; set; }
        public Guid[] BookIds { get; set; }
        public string TitleSubstring { get; set; } 
    }
}
