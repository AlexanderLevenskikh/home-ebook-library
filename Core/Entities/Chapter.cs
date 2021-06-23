using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Chapter : Entity
    {
        [Required]
        public string Description { get; set; }
        public int PageNumber { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}