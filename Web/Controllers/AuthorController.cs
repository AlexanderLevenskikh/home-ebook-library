using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Author.Queries;
using Core.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Mapper;
using Web.ViewModels;
using Web.ViewModels.Author;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<DtoList<AuthorDto>> GetAuthors(
            [FromQuery]
            GetAuthorsRequestDto request
        )
        {
            var authorsEnvelope = await _mediator.Send(
                new GetAuthorsQuery
                {
                    Filter = new AuthorsFilter
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
                        BookId = request.BookId
                    }
                }
            );

            return new DtoList<AuthorDto>
            {
                Items = ObjectMapper.Mapper.Map<List<AuthorDto>>(authorsEnvelope.Authors),
                Count = authorsEnvelope.TotalCount
            };
        }
    }
}
