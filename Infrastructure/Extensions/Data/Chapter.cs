using System;
using System.Linq;
using Core.Entities;
using Core.Filters;

namespace Infrastructure.Extensions.Data
{
    public static partial class DbContextExtensions
    {
        private const int MaxChaptersTake = 500;
        public static IQueryable<Chapter> FilterBy(this IQueryable<Chapter> chapters, ChaptersFilter filter)
        {
            return chapters.FilterByBookId(filter.BookId)
                .FilterByTitle(filter.Title)
                .Skip(filter.Offset ?? 0)
                .Take(
                    filter.Limit,
                    filter.IgnoreLimit.HasValue && filter.IgnoreLimit.Value
                        ? (int?) null
                        : MaxChaptersTake);
        }

        public static IQueryable<Chapter> FilterByBookId(this IQueryable<Chapter> chapters, Guid? bookId)
        {
            return bookId == null || bookId == Guid.Empty
                ? chapters
                : chapters.Where(a => a.BookId == bookId);
        }

        public static IQueryable<Chapter> FilterByTitle(this IQueryable<Chapter> chapters, StringFilter title)
        {
            if (title == null)
            {
                return chapters;
            }

            return title.MatchingType switch
            {
                StringMatchingType.Exact => chapters.Where(a => a.Title == title.Data.Trim()),
                StringMatchingType.Substring => chapters.Where(a => a.Title.Contains(title.Data.Trim())),
                _ => chapters
            };
        }
    }
}
