using System;
using System.Collections.Generic;
using Application.Book.Envelopes;
using MediatR;

namespace Application.Book.Commands
{
    public class CreateBookChaptersData
    {
        public string Title { get; set; }
        public int Level { get; set; }
    }
    
    public class CreateBookCommand : IRequest<BookEnvelope>
    {
        public string Title { get; set; }
        public Guid ContentId { get; set; }
        public Guid? ImageId { get; set; }
        public List<string> Authors { get; set; }
        public List<CreateBookChaptersData> Chapters { get; set; }
    }
}
