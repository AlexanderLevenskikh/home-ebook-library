using System;
using System.Linq;
using Core.Entities;
using Core.Filters;

namespace Infrastructure.Extensions.Data
{
    public static partial class DbContextExtensions
    {
        private const int MaxAuthorsTake = 500;
        public static IQueryable<Author> FilterBy(this IQueryable<Author> authors, AuthorsFilter filter)
        {
            return authors.FilterByBookId(filter.BookId)
                .FilterByBookIds(filter.BookIds)
                .FilterByTitle(filter.Title)
                .Skip(filter.Offset ?? 0)
                .Take(
                    filter.Limit,
                    filter.IgnoreLimit.HasValue && filter.IgnoreLimit.Value
                        ? (int?) null
                        : MaxAuthorsTake);
        }
        
        public static IQueryable<Author> FilterByBookIds(this IQueryable<Author> authors, Guid[] bookIds)
        {
            return bookIds == null || bookIds.Length == 0
                ? authors
                : authors.Where(a => a.Books.Any(b => bookIds.Contains(b.Id)));
        }

        public static IQueryable<Author> FilterByBookId(this IQueryable<Author> authors, Guid? bookId)
        {
            return bookId == null || bookId == Guid.Empty
                ? authors
                : authors.Where(a => a.Books.Any(b => b.Id == bookId));
        }

        public static IQueryable<Author> FilterByTitle(this IQueryable<Author> authors, StringFilter title)
        {
            if (title == null)
            {
                return authors;
            }

            return title.MatchingType switch
            {
                StringMatchingType.Exact => authors.Where(a => a.Title == title.Data.Trim()),
                StringMatchingType.Substring => authors.Where(a => a.Title.Contains(title.Data.Trim())),
                _ => authors
            };
        }
    }
}
