using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS.Models.Events
{
    [Serializable]
    public class BookCreated : IEvent
    {
        public string Title { get; set; }
    }
}