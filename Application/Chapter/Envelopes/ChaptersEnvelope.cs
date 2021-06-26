using System.Collections.Generic;
using Application.Envelopes.Base;

namespace Application.Chapter.Envelopes
{
    public class ChaptersEnvelope : ListEnvelope
    {
        public List<Core.Entities.Chapter> Chapters { get; set; }
    }
}
