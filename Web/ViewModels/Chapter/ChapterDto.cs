using System;
using Web.ViewModels.Shared;

namespace Web.ViewModels.Chapter
{
    public class ChapterDto : Dto<Guid>
    {
        public string Title { get; set; } 
        public int Level { get; set; }
    }
}
