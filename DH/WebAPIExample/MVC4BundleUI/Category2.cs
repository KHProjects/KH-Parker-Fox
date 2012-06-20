// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using Newtonsoft.Json.Linq;
using JsonCSharpClassGenerator;

namespace MyProject.JsonTypes
{

    internal class Category2
    {

        private JObject __jobject;
        public Category2(JObject obj)
        {
            this.__jobject = obj;
        }

        public string Alias
        {
            get
            {
                return JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(__jobject, "alias"));
            }
        }

        public string Type
        {
            get
            {
                return JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(__jobject, "type"));
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Files _files;
        public Files Files
        {
            get
            {
                if(_files == null)
                    _files = JsonClassHelper.ReadStronglyTypedObject<Files>(JsonClassHelper.GetJToken<JObject>(__jobject, "files"));
                return _files;
            }
        }

    }
}
