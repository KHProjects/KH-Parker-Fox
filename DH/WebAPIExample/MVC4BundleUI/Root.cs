// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using Newtonsoft.Json.Linq;
using JsonCSharpClassGenerator;
using MyProject.JsonTypes;

namespace MVC4BundleUI
{

    internal class Root
    {

        public Root(string json)
         : this(JObject.Parse(json))
        {
        }

        private JObject __jobject;
        public Root(JObject obj)
        {
            this.__jobject = obj;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Categories _categories;
        public Categories Categories
        {
            get
            {
                if(_categories == null)
                    _categories = JsonClassHelper.ReadStronglyTypedObject<Categories>(JsonClassHelper.GetJToken<JObject>(__jobject, "categories"));
                return _categories;
            }
        }

    }
}
