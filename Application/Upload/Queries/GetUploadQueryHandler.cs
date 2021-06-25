using System.Threading;
using System.Threading.Tasks;
using Application.Upload.Envelopes;
using Core.Repositories;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Upload.Queries
{
    public class GetUploadHandler : IRequestHandler<GetUploadQuery, UploadEnvelope>
    {
        private readonly IUploadRepository _uploadRepository;

        public GetUploadHandler(IUploadRepository uploadRepository)
        {
            _uploadRepository = uploadRepository;
        }

        public async Task<UploadEnvelope> Handle(GetUploadQuery request, CancellationToken cancellationToken)
        {
            var upload = await _uploadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (upload == null)
            {
                throw new NotFoundException(ResourceType.Upload);
            }

            return new UploadEnvelope(upload);
        }
    }
}
