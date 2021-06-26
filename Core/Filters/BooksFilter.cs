using System;

namespace Core.Filters
{
    public class BooksFilter : PagingFilter
    {
        public Guid? AuthorId { get; set; }
        public StringFilter Title { get; set; }
    }
}
