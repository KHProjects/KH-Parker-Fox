﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Subscriptions.Messaging.Events
{
    public class PublicationActivated
    {
        public Guid PublicationId { get; set; }
    }
}