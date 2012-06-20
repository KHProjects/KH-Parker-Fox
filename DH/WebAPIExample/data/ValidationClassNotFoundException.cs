using System;
using System.Linq;

namespace Data
{
 public class ValidationClassNotFoundException : Exception
 {
  public ValidationClassNotFoundException() : base("You are using the ValidationFilter Attribute but a suitable validation class could not be located.")
  {
  }
 }
}