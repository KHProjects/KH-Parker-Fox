using ParkerFox.Core.DataTransferObjects.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Application.Providers
{
    public interface IStoryProvider
    {
        Task<List<Story>> Query(string query);
    }
}
