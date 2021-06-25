using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public Guid ContentId { get; set; }
        public Guid? ImageId { get; set; }
        public Upload Content { get; set; }
        public Upload Image { get; set; }
        public List<Chapter> Chapters { get; set; }
        public List<Author> Authors { get; set; }
    }
}