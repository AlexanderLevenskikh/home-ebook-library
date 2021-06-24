using System;
using System.Collections.Generic;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Book : Entity
    {
        public string Caption { get; set; } = default!;
        public string? Description { get; set; }
        public Guid UploadId { get; set; } = default!;
        public Upload Upload { get; set; } = default!;
        public List<Chapter> Chapters { get; set; } = default!;
    }
}