using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Book : Entity
    {
        [Required]
        public string Caption { get; set; }
        public string Description { get; set; }
        public Guid UploadId { get; set; }
        
        public Upload Upload { get; set; }
        public List<Chapter> Chapters { get; set; }
    }
}