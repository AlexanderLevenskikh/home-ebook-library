using System.Collections.Generic;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Author : Entity
    {
        public string Title { get; set; }
        public List<Book> Books { get; set; }
    }
}
