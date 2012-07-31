using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using Newtonsoft.Json;

namespace ParkerFox.Site.Component.MediaTypeFormatters
{
    public class BsonMediaTypeFormatter : MediaTypeFormatter
    {
        private JsonSerializerSettings _jsonSerializerSettings;

        public BsonMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/bson"));
            _jsonSerializerSettings = CreateDefaultSerializerSettings();
        }

        public JsonSerializerSettings SerializerSettings
        {
            get { return _jsonSerializerSettings; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Value is null");

                _jsonSerializerSettings = value;
            }
        }

        public override bool CanReadType(Type type)
        {
            if (type == null) throw new ArgumentNullException("type is null");
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            throw new NotImplementedException();
        }

        private JsonSerializerSettings CreateDefaultSerializerSettings()
        {
            return new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                TypeNameHandling = TypeNameHandling.None
            };
        }
    }
}