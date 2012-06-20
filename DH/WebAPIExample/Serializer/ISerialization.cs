using System;
using System.IO;
using System.Linq;

namespace Serializer
{
 public interface ISerialization
 {
  string Serialize<T>(object o);

  object DeSerialize<T>(Stream stream);

  object DeSerialize<T>(string content);
 }
}