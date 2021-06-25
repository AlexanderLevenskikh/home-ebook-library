using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Extensions;
using VersOne.Epub;

namespace Infrastructure.Services.Ebook
{
    public class EpubParser : IEbookParserImpl
    {
        public async Task<EBookParsingResult> Parse(byte[] content)
        {
            await using var stream = new MemoryStream(content);
            var reader = await EpubReader.ReadBookAsync(stream);

            return new EBookParsingResult
            {
                Authors = reader.AuthorList,
                Title = reader.Title,
                CoverImage = reader.Content.Cover.Content,
                CoverImageName = reader.Content.Cover.FileName,
                CoverImageContentType = reader.Content.Cover.ContentMimeType,
                Chapters = ParseChapters(reader),
            };
        }

        private List<EBookParsingResultChapters> ParseChapters(EpubBook reader)
        {
            var navList = reader.Navigation.ToPlainList();

            return navList.Select(
                    item =>
                    {
                        var (chapter, level) = item;

                        return new EBookParsingResultChapters
                        {
                            Title = chapter.Title,
                            Level = level
                        };
                    }
                )
                .ToList();
        }
    }
}
