using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using ParkerFox.Core.Entities.Ecommerce;

namespace ParkerFox.Site.Component.MediaTypeFormatters
{
    public class SyndicationMediaTypeFormatter : MediaTypeFormatter
    {
        private readonly string atomMimeType = "application/atom+xml";
        private readonly string rssMimeType = "application/rss+xml";

        public SyndicationMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(atomMimeType));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(rssMimeType));
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(Product);
        }

        //public override Task WriteToStreamAsync(Type type, object value, Stream stream, HttpContentHeaders contentHeaders, System.Net.TransportContext transportContext)
        //{
        //    return Task.Factory.StartNew(() =>
        //    {
        //        BuildSyndicationFeed(value, stream, contentHeaders.ContentType.MediaType);
        //    });
        //}

        public override bool CanReadType(Type type)
        {
            throw new NotImplementedException();
        }

        private void BuildSyndicationFeed(object model, Stream stream, string mediaType)
        {
            throw new NotImplementedException();
        }
    }
}