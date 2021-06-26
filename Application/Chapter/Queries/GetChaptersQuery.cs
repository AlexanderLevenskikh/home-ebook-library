using Application.Chapter.Envelopes;
using Core.Filters;
using MediatR;

namespace Application.Chapter.Queries
{
    public class GetChaptersQuery : IRequest<ChaptersEnvelope>
    {
        public ChaptersFilter Filter { get; set; }
    }
}
