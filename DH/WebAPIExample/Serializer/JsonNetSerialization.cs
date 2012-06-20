using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Serializer
{
 public class JsonNetSerialization : ISerialization
 {
  public string Serialize<T>(object o)
  {
   return JsonConvert.SerializeObject((T)o);
  }

  public object DeSerialize<T>(System.IO.Stream stream)
  {
   return DeSerialize<T>(new StreamReader(stream).ReadToEnd());
  }

  public object DeSerialize<T>(string content)
  {
   return JsonConvert.DeserializeObject<T>(content);
  }
 }
}