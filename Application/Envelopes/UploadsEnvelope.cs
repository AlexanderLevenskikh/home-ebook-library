using System.Collections.Generic;
using Application.Envelopes.Base;
using Core.Entities;

namespace Application.Envelopes
{
    public class UploadsEnvelope : ListEnvelope
    {
        public List<Upload> Uploads { get; set; }
    }
}