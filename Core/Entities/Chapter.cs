using System;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Chapter : Entity
    {
        public string Description { get; set; } = default!;
        public int PageNumber { get; set; } = default!;
        public Guid BookId { get; set; } = default!;
        public Book Book { get; set; } = default!;
    }
}