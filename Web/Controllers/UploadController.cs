using System;
using System.Threading.Tasks;
using Application.Upload.Commands;
using Application.Upload.Queries;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/upload")]
    public class UploadController
    {
        private readonly IMediator _mediator;

        public UploadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Upload> CreateUpload(
            [FromBody]
            IFormFile file
        )
        {
            var envelope = await _mediator.Send(
                new CreateUploadsCommand
                {
                    Uploads = new[]
                    {
                        new CreateUploadCommandData
                        {
                            FileName = file.Name,
                            ContentType = file.ContentType,
                            FileSize = file.Length
                        }
                    }
                }
            );

            // TODO save file, move to service
            return envelope.Uploads[0];
        }

        [HttpGet("{id}")]
        public async Task<Upload> GetUpload(Guid id)
        {
            var envelope = _mediator.Send(new GetUploadQuery(id));
            
            return 
        }
    }
}
