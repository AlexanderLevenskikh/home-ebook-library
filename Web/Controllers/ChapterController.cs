using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Chapter.Queries;
using Core.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Mapper;
using Web.ViewModels;
using Web.ViewModels.Chapter;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/chapter")]
    public class ChapterController
    {
        private readonly IMediator _mediator;

        public ChapterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("list")]
        public async Task<DtoList<ChapterDto>> GetChapters(
            [FromQuery]
            GetChaptersRequestDto request
        )
        {
            var authorsEnvelope = await _mediator.Send(
                new GetChaptersQuery
                {
                    Filter = new ChaptersFilter
                    {
                        IgnoreLimit = true,
                        BookId = request.BookId
                    }
                }
            );

            return new DtoList<ChapterDto>
            {
                Items = ObjectMapper.Mapper.Map<List<ChapterDto>>(authorsEnvelope.Chapters),
                Count = authorsEnvelope.TotalCount
            };
        }
    }
}
