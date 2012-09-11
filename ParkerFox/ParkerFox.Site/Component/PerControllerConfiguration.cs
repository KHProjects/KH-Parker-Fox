using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using ParkerFox.Site.Component.MediaTypeFormatters;

namespace ParkerFox.Site.Component
{
    /// <summary>
    /// http://blogs.msdn.com/b/jmstall/archive/2012/05/11/per-controller-configuration-in-webapi.aspx
    /// </summary>
    public class PerControllerConfiguration : Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            controllerSettings.Services.Replace(typeof (IActionValueBinder), new DefaultActionValueBinder());
            controllerSettings.Formatters.Add(new BsonMediaTypeFormatter());
        }
    }
}