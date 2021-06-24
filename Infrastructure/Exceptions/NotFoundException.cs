using System;

namespace Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {
        public ResourceType ResourceType { get; }

        public NotFoundException(ResourceType resourceType, string? message = null) : base(message)
        {
            ResourceType = resourceType;
        }

        public NotFoundException(ResourceType resourceType,
            Exception? innerException,
            string? message = null) : base(
            message, innerException)
        {
            ResourceType = resourceType;
        }
    }
}
