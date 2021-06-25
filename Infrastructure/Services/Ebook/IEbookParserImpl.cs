using System.Threading.Tasks;

namespace Infrastructure.Services.Ebook
{
    public interface IEbookParserImpl
    {
        public Task<EBookParsingResult> Parse(byte[] content);
    }
}
