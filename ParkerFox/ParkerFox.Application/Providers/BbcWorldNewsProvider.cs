using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Core.DataTransferObjects.Providers;
using System.Net;
using System.Xml.Linq;
using System.Xml;

namespace ParkerFox.Application.Providers
{
    /// <summary>
    /// http://newsrss.bbc.co.uk/rss/newsonline_uk_edition/world/rss.xml
    /// </summary>
    public sealed class BbcWorldNewsProvider : IStoryProvider
    {
        private Uri _feedUri = new Uri("http://newsrss.bbc.co.uk/rss/newsonline_uk_edition/world/rss.xml");
        public async Task<List<Story>> Query(string query)
        {
            string rss = await new WebClient().DownloadStringTaskAsync(_feedUri);

//            XDocument.Parse(rss).Descendants()

            return new List<Story>();
        }
    }
}
