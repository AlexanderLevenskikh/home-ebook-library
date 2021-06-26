using System;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Upload : Entity
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
        public UploadProvider UploadProvider { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }

    public enum UploadProvider
    {
        Book = 1,
        Image = 2,
    }
}