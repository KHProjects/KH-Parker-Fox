﻿using MagHag.Core.Messaging.EventSourcing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Subscriptions.Core.Events
{
    public class SubscribedToPublication : IEvent
    {
        public Guid PublicationId { get; set; }
    }
}
