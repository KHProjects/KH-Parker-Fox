using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Infrastructure.Web
{
    /// <summary>
    /// DataContractJsonSerializer is not that great apparently http://wildermuth.com/2012/2/22/WebAPI_for_the_MVC_Guy
    /// </summary>
    public class JavascriptSerializerFormatter : MediaTypeFormatter
    {
        public JavascriptSerializerFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public override bool CanReadType(Type type)
        {
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            return true;
        }
    }
}
