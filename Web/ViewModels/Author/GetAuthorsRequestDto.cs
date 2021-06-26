using System;

namespace Web.ViewModels.Author
{
    public class GetAuthorsRequestDto
    {
        public Guid? BookId { get; set; }
        public string TitleSubstring { get; set; } 
    }
}
