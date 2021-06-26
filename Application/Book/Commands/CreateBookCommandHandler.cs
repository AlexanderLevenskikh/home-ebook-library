using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Book.Envelopes;
using Application.Upload.Commands;
using Core.Entities;
using Core.Filters;
using Core.Repositories;
using MediatR;

namespace Application.Book.Commands
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookEnvelope>
    {
        private readonly IMediator _mediator;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IChapterRepository _chapterRepository;

        public CreateBookCommandHandler(
            IMediator mediator,
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            IChapterRepository chapterRepository
        )
        {
            _mediator = mediator;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _chapterRepository = chapterRepository;
        }

        public async Task<BookEnvelope> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var authors = await request.Authors.ToAsyncEnumerable()
                .SelectAwait(author => GetOrCreateAuthorAsync(author, cancellationToken))
                .ToListAsync(cancellationToken: cancellationToken);

            var book = await _bookRepository.AddAsync(
                new Core.Entities.Book
                {
                    Id = new Guid(),
                    Title = request.Title,
                    ContentId = request.ContentId,
                    ImageId = request.ImageId,
                    Authors = authors,
                },
                cancellationToken
            );

            var chapters = await request.Chapters.ToAsyncEnumerable()
                .SelectAwait(
                    chapter => CreateChapterAsync(book.Id, chapter.Title, chapter.Level, cancellationToken)
                )
                .ToListAsync(cancellationToken: cancellationToken);

            book.Chapters = chapters;

            return new BookEnvelope(book);
        }

        private async ValueTask<Core.Entities.Author> GetOrCreateAuthorAsync(
            string authorTitle,
            CancellationToken cancellationToken
        )
        {
            return await _authorRepository.FindFirstOrDefaultByFilterAsync(new AuthorsFilter
                   {
                       Title = new StringFilter
                       {
                           Data = authorTitle,
                           MatchingType = StringMatchingType.Exact
                       }
                   }, cancellationToken) ??
                   await _authorRepository.AddAsync(
                       new Core.Entities.Author
                       {
                           Id = new Guid(),
                           Title = authorTitle
                       },
                       cancellationToken
                   );
        }

        private async ValueTask<Chapter> CreateChapterAsync(
            Guid bookId,
            string chapterTitle,
            int level,
            CancellationToken cancellationToken
        )
        {
            return await _chapterRepository.AddAsync(
                new Chapter
                {
                    Id = new Guid(),
                    Title = chapterTitle,
                    Level = level,
                    BookId = bookId,
                },
                cancellationToken
            );
        }
    }
}
