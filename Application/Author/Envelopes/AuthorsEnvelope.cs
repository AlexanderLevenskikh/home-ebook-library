using System.Collections.Generic;
using Application.Envelopes.Base;

namespace Application.Author.Envelopes
{
    public class AuthorsEnvelope : ListEnvelope
    {
        public List<Core.Entities.Author> Authors { get; set; }
    }
}
