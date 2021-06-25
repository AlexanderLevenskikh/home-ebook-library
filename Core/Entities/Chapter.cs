using System;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Chapter : Entity
    {
        public string Title { get; set; } 
        public int Level { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}