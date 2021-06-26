using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Author.Queries;
using Application.Book.Commands;
using Application.Book.Queries;
using Application.Content;
using Application.Upload.Commands;
using Core.Entities;
using Core.Filters;
using Infrastructure.Exceptions;
using Infrastructure.Services;
using Infrastructure.Services.Ebook;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Mapper;
using Web.ViewModels;
using Web.ViewModels.Author;
using Web.ViewModels.Book;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController
    {
        private readonly IMediator _mediator;
        private readonly IEBookParser _bookParser;
        private readonly IContentService _contentService;
        private readonly IContentPathProvider _contentPathProvider;

        public BookController(
            IMediator mediator,
            IEBookParser bookParser,
            IContentService contentService,
            IContentPathProvider contentPathProvider
        )
        {
            _mediator = mediator;
            _bookParser = bookParser;
            _contentService = contentService;
            _contentPathProvider = contentPathProvider;
        }
        
        [HttpGet("list")]
        public async Task<DtoList<BookDto>> GetBooks(
            [FromQuery]
            GetBooksRequestDto request
        )
        {
            var authorsEnvelope = await _mediator.Send(
                new GetBooksQuery
                {
                    Filter = new BooksFilter
                    {
                        Limit = request.Limit,
                        Offset = request.Offset,
                        Title = request.TitleSubstring != null
                            ? new StringFilter
                            {
                                Data = request.TitleSubstring,
                                MatchingType = StringMatchingType.Substring
                            }
                            : null,
                        AuthorId = request.AuthorId
                    }
                }
            );

            return new DtoList<BookDto>
            {
                Items = ObjectMapper.Mapper.Map<List<BookDto>>(authorsEnvelope.Books),
                Count = authorsEnvelope.TotalCount
            };
        }

        [HttpPost]
        public async Task<BookDto> CreateBook(
            [FromBody]
            CreateBookRequestDto request
        )
        {
            var content = _contentService.Find(
                _contentPathProvider.GetFullPath(ContentType.Upload, request.UploadId.ToString())
            );
            
            if (content == null)
            {
                throw new NotFoundException(ResourceType.UploadFile);
            }
            
            var parsedBook = await _bookParser.Parse(content, request.Type);

            Upload imageUpload = null;
            if (parsedBook.CoverImage != null)
            {
                var envelope = await _mediator.Send(
                    new CreateUploadsCommand
                    {
                        Uploads = new []
                        {
                            new CreateUploadCommandData
                            {
                                FileName = parsedBook.CoverImageName,
                                ContentType = parsedBook.CoverImageContentType,
                                FileSize = parsedBook.CoverImage.Length,
                                UploadProvider = UploadProvider.Image
                            }
                        }
                    }
                );

                imageUpload = envelope.Uploads[0];

                try
                {
                    _contentService.Save(
                        _contentPathProvider.GetFullPath(ContentType.Upload, imageUpload.Id.ToString()),
                        parsedBook.CoverImage
                    );
                }
                catch (Exception e)
                {
                    await _mediator.Send(new DeleteUploadCommand(imageUpload.Id));
                    throw;
                }
            }
            
            var bookEnvelope = await _mediator.Send(
                new CreateBookCommand
                {
                    Title = parsedBook.Title,
                    ImageId = imageUpload?.Id,
                    Authors = parsedBook.Authors,
                    Chapters = parsedBook.Chapters.Select(
                            chapter => new CreateBookChaptersData
                            {
                                Title = chapter.Title,
                                Level = chapter.Level,
                            }
                        )
                        .ToList(),
                    ContentId = request.UploadId
                }
            );

            return ObjectMapper.Mapper.Map<BookDto>(bookEnvelope.Book);
        }
    }
}
