using Application.Upload.Envelopes;
using MediatR;

namespace Application.Upload.Commands
{
    public class CreateUploadCommandData
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
    }
    
    public class CreateUploadsCommand : IRequest<UploadsEnvelope>
    {
        public CreateUploadCommandData[] Uploads { get; set; }
    }
}