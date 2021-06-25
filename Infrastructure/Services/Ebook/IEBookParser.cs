using System.Threading.Tasks;

namespace Infrastructure.Services.Ebook
{
    public interface IEBookParser
    {
        public Task<EBookParsingResult> Parse(byte[] content, EBookType type);
    }
}
