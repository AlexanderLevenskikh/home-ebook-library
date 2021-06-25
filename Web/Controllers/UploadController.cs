using System;
using System.Threading.Tasks;
using Application.Content;
using Application.Upload.Commands;
using Application.Upload.Queries;
using Infrastructure.Exceptions;
using Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;
using Web.Mapper;
using Web.ViewModels.Upload;

namespace Web.Controllers
{
    [Route("api/upload")]
    public class UploadController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IContentService _contentService;
        private readonly IContentPathProvider _contentPathProvider;

        public UploadController(
            IMediator mediator,
            IContentService contentService,
            IContentPathProvider contentPathProvider
        )
        {
            _mediator = mediator;
            _contentService = contentService;
            _contentPathProvider = contentPathProvider;
        }

        [HttpPost]
        public async Task<UploadDto> CreateUpload(
            [FromForm]
            UploadFileRequestDto dto
        )
        {
            var envelope = await _mediator.Send(
                new CreateUploadsCommand
                {
                    Uploads = new[]
                    {
                        new CreateUploadCommandData
                        {
                            FileName = dto.File.FileName,
                            ContentType = dto.File.ContentType,
                            FileSize = dto.File.Length
                        }
                    }
                }
            );

            var upload = envelope.Uploads[0];

            try
            {
                _contentService.Save(
                    _contentPathProvider.GetFullPath(ContentType.Upload, upload.Id.ToString()),
                    dto.File.GetBytes()
                );
            }
            catch (Exception e)
            {
                await _mediator.Send(new DeleteUploadCommand(upload.Id));
                throw;
            }

            return ObjectMapper.Mapper.Map<UploadDto>(envelope.Uploads[0]);
        }

        [HttpGet("{id}")]
        public async Task<UploadDto> GetUpload(Guid id)
        {
            var envelope = await _mediator.Send(new GetUploadQuery(id));

            return ObjectMapper.Mapper.Map<UploadDto>(envelope.Upload);
        }

        [HttpGet("{id}/file")]
        public async Task<FileResult> GetUploadFile(Guid id)
        {
            var envelope = await _mediator.Send(new GetUploadQuery(id));

            var content = _contentService.Find(
                _contentPathProvider.GetFullPath(ContentType.Upload, id.ToString())
            );

            if (content == null)
            {
                throw new NotFoundException(ResourceType.UploadFile);
            }

            return File(content, envelope.Upload.ContentType, envelope.Upload.Name);
        }
    }
}
