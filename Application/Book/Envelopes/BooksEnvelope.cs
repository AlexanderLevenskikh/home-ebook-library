using System.Collections.Generic;
using Application.Envelopes.Base;

namespace Application.Book.Envelopes
{
    public class BooksEnvelope : ListEnvelope
    {
        public List<Core.Entities.Book> Books { get; set; }
    }
}
