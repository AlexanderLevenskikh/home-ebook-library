using Application.Author.Envelopes;
using Core.Filters;
using MediatR;

namespace Application.Author.Queries
{
    public class GetAuthorsQuery : IRequest<AuthorsEnvelope>
    {
        public AuthorsFilter Filter { get; set; }
    }
}
