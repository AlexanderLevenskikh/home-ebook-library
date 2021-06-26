using Application.Book.Envelopes;
using Core.Filters;
using MediatR;

namespace Application.Book.Queries
{
    public class GetBooksQuery : IRequest<BooksEnvelope>
    {
        public BooksFilter Filter { get; set; }
    }
}
