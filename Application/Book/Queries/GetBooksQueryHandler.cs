using System.Threading;
using System.Threading.Tasks;
using Application.Book.Envelopes;
using Core.Repositories;
using MediatR;

namespace Application.Book.Queries
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, BooksEnvelope>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BooksEnvelope> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.FindByFilterAsync(
                request.Filter, cancellationToken);

            request.Filter.ResetPagingAndIgnoreLimits();
            var authorsCount =  await _bookRepository.CountByFilterAsync(
                request.Filter, cancellationToken);

            return new BooksEnvelope
            {
                Books = books,
                TotalCount = authorsCount
            };
        }
    }
}
