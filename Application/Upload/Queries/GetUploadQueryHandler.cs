using System.Threading;
using System.Threading.Tasks;
using Application.Upload.Envelopes;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Upload.Queries
{
    public class GetUploadHandler : IRequestHandler<GetUploadQuery, UploadEnvelope>
    {
        private readonly EbookLibraryContext _context;

        public GetUploadHandler(EbookLibraryContext context)
        {
            _context = context;
        }

        public async Task<UploadEnvelope> Handle(GetUploadQuery request, CancellationToken cancellationToken)
        {
            var upload = await _context.Uploads
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken: cancellationToken);

            if (upload == null)
            {
                throw new NotFoundException(ResourceType.Upload);
            }

            return new UploadEnvelope(upload);
        }
    }
}
