using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Upload.Envelopes;
using Infrastructure.Data;
using MediatR;

namespace Application.Upload.Commands
{
    public class CreateUploadCommandHandler : IRequestHandler<CreateUploadsCommand, UploadsEnvelope>
    {
        private readonly EbookLibraryContext _context;

        public CreateUploadCommandHandler(EbookLibraryContext context)
        {
            _context = context;
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
                    CreatedAt = DateTimeOffset.Now
                })
                .ToList();

            await _context.Uploads.AddRangeAsync(uploads, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new UploadsEnvelope
            {
                Uploads = uploads,
                Count = uploads.Count
            };
        }
    }
}