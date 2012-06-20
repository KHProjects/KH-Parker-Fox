using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Data
{
 public class Product
 {

  public int Id {get; set;}

  [Required]
  public string Name {get; set;}
  
  [Required]
  public decimal Price {get; set;}

 }
}