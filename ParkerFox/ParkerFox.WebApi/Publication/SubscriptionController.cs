using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ParkerFox.WebApi.Publication.Dto;

namespace ParkerFox.WebApi.Publication
{
    public class SubscriptionController : ApiController
    {
        public IEnumerable<SubscriptionInfo> Get()
        {
            return new List<SubscriptionInfo>
                {
                    new SubscriptionInfo{PublicationName = "Publication One", StartDate = "1 Jan 12", EndDate = "31 Dec 12"},
                    new SubscriptionInfo{PublicationName = "Publication Two", StartDate = "13 Aug 12", EndDate = "5 Apr 13"}
                };
        }
    }
}
