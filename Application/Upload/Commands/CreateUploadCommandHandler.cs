using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Upload.Envelopes;
using Core.Repositories;
using Infrastructure.Data;
using MediatR;

namespace Application.Upload.Commands
{
    public class CreateUploadCommandHandler : IRequestHandler<CreateUploadsCommand, UploadsEnvelope>
    {
        private readonly IUploadRepository _uploadRepository;

        public CreateUploadCommandHandler(IUploadRepository uploadRepository)
        {
            _uploadRepository = uploadRepository;
        }

        public async Task<UploadsEnvelope> Handle(CreateUploadsCommand request, CancellationToken cancellationToken)
        {
            var uploads = request.Uploads
                .Select(upload => new Core.Entities.Upload
                {
                    Id = new Guid(),
                    Name = upload.FileName,
                    Size = upload.FileSize,
                    ContentType = upload.ContentType,
                    CreatedAt = DateTimeOffset.Now,
                    UploadProvider = upload.UploadProvider
                })
                .ToList();

            await _uploadRepository.AddRangeAsync(uploads, cancellationToken);

            return new UploadsEnvelope
            {
                Uploads = uploads,
                TotalCount = uploads.Count
            };
        }
    }
}