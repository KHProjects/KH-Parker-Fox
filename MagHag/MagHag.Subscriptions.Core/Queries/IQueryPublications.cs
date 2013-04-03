﻿using MagHag.Subscriptions.Core.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Subscriptions.Core.Queries
{
    public interface IQueryPublications
    {
        IEnumerable<ActivePublication> GetActive();
    }
}