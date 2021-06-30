using System;

namespace Core.Filters
{
    public class AuthorsFilter : PagingFilter
    {
        public Guid? BookId { get; set; }
        public Guid[] BookIds { get; set; }
        public StringFilter Title { get; set; }
    }
}
