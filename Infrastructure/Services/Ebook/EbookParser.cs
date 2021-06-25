using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services.Ebook
{
    public class EbookParser : IEBookParser
    {
        private readonly Dictionary<EBookType, IEbookParserImpl> parsers = new()
        {
            {EBookType.Epub, new EpubParser()}
        };


        public Task<EBookParsingResult> Parse(byte[] content, EBookType type)
        {
            return parsers[type].Parse(content);
        }
    }
}
