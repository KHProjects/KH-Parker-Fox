using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC
{
    /// <summary>
    /// Plugged in using web.config.. there are a few module from the framework plugged in using   %WINDOWS%\Microsoft.NET\Framework\v{###}\Config\web.config
    /// </summary>
    public class MyModule : IHttpModule
    {
        /// <summary>
        /// This method may get called a few times: http://stackoverflow.com/questions/3370839/advanced-how-many-times-does-httpmodule-init-method-get-called-during-applica
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += (sender, args) => { };
        }

        public void Dispose()
        {
        }
    }
}