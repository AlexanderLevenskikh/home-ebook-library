using System;
using MediatR;

namespace Application.Upload.Commands
{
    public record DeleteUploadCommand(Guid Id) : IRequest;
}
