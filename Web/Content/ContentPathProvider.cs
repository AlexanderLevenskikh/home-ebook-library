using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Web.Constants;

namespace Application.Content
{
    public class ContentPathProvider : IContentPathProvider
    {
        private const string Uploads = "Uploads";
        private readonly IConfiguration _configuration;

        public ContentPathProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetFullPath(ContentType contentType, string path)
        {
            return contentType switch
            {
                ContentType.Upload => Path.Combine(
                    _configuration.GetSection(ConfigurationConstants.FileContentRoot).Value,
                    Uploads,
                    path
                ),
                _ => throw new ArgumentOutOfRangeException(nameof(contentType), contentType, null),
            };
        }
    }
}
