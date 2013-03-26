using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagHag.Subscriptions.Core.ReadModels;

namespace MagHag.Subscriptions.Core
{
    public interface IStorePublicationProjection
    {
        void Store(ActivePublication activePublication);
    }
}
