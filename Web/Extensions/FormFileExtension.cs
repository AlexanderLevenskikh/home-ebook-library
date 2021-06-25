using System.IO;
using Microsoft.AspNetCore.Http;

namespace Web.Extensions
{
    public static class FormFileExtension
    {
        public static byte[] GetBytes(
            this IFormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
