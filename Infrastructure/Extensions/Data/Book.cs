using System;
using System.Linq;
using Core.Entities;
using Core.Filters;

namespace Infrastructure.Extensions.Data
{
    public static partial class DbContextExtensions
    {
        private const int MaxBooksTake = 500;
        public static IQueryable<Book> FilterBy(this IQueryable<Book> books, BooksFilter filter)
        {
            return books.FilterByAuthorId(filter.AuthorId)
                .FilterByTitle(filter.Title)
                .Skip(filter.Offset ?? 0)
                .Take(
                    filter.Limit,
                    filter.IgnoreLimit.HasValue && filter.IgnoreLimit.Value
                        ? (int?) null
                        : MaxAuthorsTake);
        }

        public static IQueryable<Book> FilterByAuthorId(this IQueryable<Book> books, Guid? authorId)
        {
            return authorId == null || authorId == Guid.Empty
                ? books
                : books.Where(a => a.Authors.Any(b => b.Id == authorId));
        }

        public static IQueryable<Book> FilterByTitle(this IQueryable<Book> books, StringFilter title)
        {
            if (title == null)
            {
                return books;
            }

            return title.MatchingType switch
            {
                StringMatchingType.Exact => books.Where(a => a.Title == title.Data.Trim()),
                StringMatchingType.Substring => books.Where(a => a.Title.Contains(title.Data.Trim())),
                _ => books
            };
        }
    }
}
