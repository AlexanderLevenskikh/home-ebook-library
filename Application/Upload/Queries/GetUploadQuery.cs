using System;
using Application.Upload.Envelopes;
using MediatR;

namespace Application.Upload.Queries
{
    public record GetUploadQuery(Guid Id) : IRequest<UploadEnvelope>;
}