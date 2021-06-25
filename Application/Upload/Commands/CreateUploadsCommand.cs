using Application.Upload.Envelopes;
using Core.Entities;
using MediatR;

namespace Application.Upload.Commands
{
    public class CreateUploadCommandData
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
        public UploadProvider UploadProvider { get; set; }
    }
    
    public class CreateUploadsCommand : IRequest<UploadsEnvelope>
    {
        public CreateUploadCommandData[] Uploads { get; set; }
    }
}