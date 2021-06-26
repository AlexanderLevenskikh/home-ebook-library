using System.Threading;
using System.Threading.Tasks;
using Application.Chapter.Envelopes;
using Core.Repositories;
using MediatR;

namespace Application.Chapter.Queries
{
    public class GetChaptersQueryHandler : IRequestHandler<GetChaptersQuery, ChaptersEnvelope>
    {
        private readonly IChapterRepository _chapterRepository;

        public GetChaptersQueryHandler(IChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }

        public async Task<ChaptersEnvelope> Handle(GetChaptersQuery request, CancellationToken cancellationToken)
        {
            var chapters = await _chapterRepository.FindByFilterAsync(
                request.Filter, cancellationToken);

            request.Filter.ResetPagingAndIgnoreLimits();
            var authorsCount =  await _chapterRepository.CountByFilterAsync(
                request.Filter, cancellationToken);

            return new ChaptersEnvelope
            {
                Chapters = chapters,
                TotalCount = authorsCount
            };
        }
    }
}
