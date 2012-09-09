using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Core.DataTransferObjects.Providers;

namespace ParkerFox.Application.Providers
{
    public sealed class DiggStoreProvider : IStoryProvider
    {
        public Task<List<Story>> Query(string query)
        {
            throw new NotImplementedException();
        }
    }
}
