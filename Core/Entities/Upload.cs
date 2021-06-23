using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Upload : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ContentType { get; set; }
        public long Size { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}