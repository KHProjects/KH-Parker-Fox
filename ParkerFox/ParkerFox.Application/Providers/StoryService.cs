using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Core.DataTransferObjects.Providers;

namespace ParkerFox.Application.Providers
{
    public class StoryService
    {
        private List<IStoryProvider> _storyProviders;

        public StoryService()
        {
            _storyProviders = new List<IStoryProvider> {new BbcWorldNewsProvider()};
        }

        public async Task<List<Story>> GetByQuery(string query)
        {
            var results = await Task.WhenAll(_storyProviders.Select(p => p.Query(query)));

            return results.SelectMany(r => r).ToList();
        }
    }
}
