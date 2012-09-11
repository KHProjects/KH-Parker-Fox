using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace ParkerFox.Site.Component.MediaTypeFormatters
{
    /// <summary>
    /// http://www.strathweb.com/2012/07/bson-binary-json-and-how-your-web-api-can-be-even-faster/
    /// </summary>
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
            if (type == null) throw new ArgumentNullException("type is null");
            return true;
        }

        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, System.Net.Http.HttpContent content, IFormatterLogger formatterLogger)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();

            try
            {
                BsonReader reader = new BsonReader(readStream);
                if (typeof(IEnumerable).IsAssignableFrom(type)) reader.ReadRootValueAsArray = true;

                using (reader)
                {
                    var jsonSerializer = JsonSerializer.Create(_jsonSerializerSettings);
                    var output = jsonSerializer.Deserialize(reader, type);
                    if (formatterLogger != null)
                    {
                        jsonSerializer.Error += (sender, e) =>
                        {
                            Exception exception = e.ErrorContext.Error;
                            formatterLogger.LogError(e.ErrorContext.Path, exception.Message);
                            e.ErrorContext.Handled = true;
                        };
                    }
                    taskCompletionSource.SetResult(output);
                }
            }
            catch (Exception ex)
            {
                if (formatterLogger == null) throw;
                formatterLogger.LogError(String.Empty, ex.Message);
                taskCompletionSource.SetResult(GetDefaultValueForType(type));
            }

            return taskCompletionSource.Task;
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();
            using (BsonWriter bsonWriter = new BsonWriter(writeStream) { CloseOutput = false })
            {
                JsonSerializer jsonSerializer = JsonSerializer.Create(_jsonSerializerSettings);
                jsonSerializer.Serialize(bsonWriter, value);
                bsonWriter.Flush();
                taskCompletionSource.SetResult(null);
            }
            return taskCompletionSource.Task;
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