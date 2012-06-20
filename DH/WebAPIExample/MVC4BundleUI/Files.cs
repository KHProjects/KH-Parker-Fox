// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using Newtonsoft.Json.Linq;
using JsonCSharpClassGenerator;

namespace MyProject.JsonTypes
{

    internal class Files
    {

        private JObject __jobject;
        public Files(JObject obj)
        {
            this.__jobject = obj;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private File[] _file;
        public File[] File
        {
            get
            {
                if(_file == null)
                    _file = (File[])JsonClassHelper.ReadArray<File>(JsonClassHelper.GetJToken<JArray>(__jobject, "file"), JsonClassHelper.ReadStronglyTypedObject<File>, typeof(File[]));
                return _file;
            }
        }

    }
}
