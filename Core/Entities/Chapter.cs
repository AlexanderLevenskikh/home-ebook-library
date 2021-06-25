using System;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Chapter : Entity
    {
        public string Description { get; set; } 
        public int PageNumber { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}