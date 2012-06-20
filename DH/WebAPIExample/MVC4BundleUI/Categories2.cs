// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using Newtonsoft.Json.Linq;
using JsonCSharpClassGenerator;

namespace MyProject.JsonTypes
{

    internal class Categories2
    {

        private JObject __jobject;
        public Categories2(JObject obj)
        {
            this.__jobject = obj;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Category[] _category;
        public Category[] Category
        {
            get
            {
                if(_category == null)
                    _category = (Category[])JsonClassHelper.ReadArray<Category>(JsonClassHelper.GetJToken<JArray>(__jobject, "category"), JsonClassHelper.ReadStronglyTypedObject<Category>, typeof(Category[]));
                return _category;
            }
        }

    }
}
