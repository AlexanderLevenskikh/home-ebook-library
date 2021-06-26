using System;

namespace Core.Filters
{
    public class ChaptersFilter : PagingFilter
    {
        public Guid? BookId { get; set; }
        public StringFilter Title { get; set; }
    }
}
