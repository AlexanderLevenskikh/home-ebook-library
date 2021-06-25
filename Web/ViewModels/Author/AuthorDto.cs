using System;
using Web.ViewModels.Shared;

namespace Web.ViewModels.Author
{
    public class AuthorDto : Dto<Guid>
    {
        public string Title { get; set; }
    }
}
