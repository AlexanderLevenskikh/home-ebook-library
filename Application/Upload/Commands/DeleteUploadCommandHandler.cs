using System.Threading;
using System.Threading.Tasks;
using Core.Repositories;
using Infrastructure.Data;
using MediatR;

namespace Application.Upload.Commands
{
    public class DeleteUploadCommandHandler : IRequestHandler<DeleteUploadCommand>
    {
        private readonly IUploadRepository _uploadRepository;

        public DeleteUploadCommandHandler(IUploadRepository uploadRepository)
        {
            _uploadRepository = uploadRepository;
        }


        public async Task<Unit> Handle(DeleteUploadCommand request, CancellationToken cancellationToken)
        {
            var upload = await _uploadRepository.GetByIdAsync(request.Id, cancellationToken);
            await _uploadRepository.RemoveAsync(upload, cancellationToken);
            
            return await Task.FromResult(Unit.Value);
        }
    }
}
