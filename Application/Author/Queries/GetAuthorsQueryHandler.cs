using System.Threading;
using System.Threading.Tasks;
using Application.Author.Envelopes;
using Core.Repositories;
using MediatR;

namespace Application.Author.Queries
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, AuthorsEnvelope>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorsQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<AuthorsEnvelope> Handle(
            GetAuthorsQuery request,
            CancellationToken cancellationToken
        )
        {
            var authors = await _authorRepository.FindByFilterAsync(
                request.Filter, cancellationToken);

            request.Filter.ResetPagingAndIgnoreLimits();
            var authorsCount =  await _authorRepository.CountByFilterAsync(
                request.Filter, cancellationToken);

            return new AuthorsEnvelope
            {
                Authors = authors,
                TotalCount = authorsCount
            };
        }
    }
}
