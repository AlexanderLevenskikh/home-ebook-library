using System.Collections.Generic;
using Application.Envelopes.Base;

namespace Application.Upload.Envelopes
{
    public class UploadsEnvelope : ListEnvelope
    {
        public List<Core.Entities.Upload> Uploads { get; set; }
    }
}