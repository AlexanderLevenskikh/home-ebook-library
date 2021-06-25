using System.Collections.Generic;

namespace Infrastructure.Services.Ebook
{
    public class EBookParsingResult
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public List<EBookParsingResultChapters> Chapters { get; set; }
        public byte[] CoverImage { get; set; }
        public string CoverImageName { get; set; }
        public string CoverImageContentType { get; set; }
    }
}
