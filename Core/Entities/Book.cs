using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Book
    {
        [Required]
        public string Caption { get; set; }
        public string Description { get; set; }
        public Guid UploadId { get; set; }
        
        public Upload Upload { get; set; }
    }
}