using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagHag.Site.Controllers.Api
{
    public class CreatePublicationRequest
    {
        public Guid PublicationId { get; set; }

        public string Title { get; set; }
    }
}
