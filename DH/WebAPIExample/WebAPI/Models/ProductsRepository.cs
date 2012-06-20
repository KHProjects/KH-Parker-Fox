using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Models
{
 public class ProductsRepository
 {
  private static IEnumerable<Product> _data;

  public static void reset()
  {
   _data = null;
   var x = data;
  }

  public static void delete(int id)
  {
   Product fetchedProduct;

   if (id == 0)
   {
    throw new 
    Exception("The id passed must be non-zero.");
   }

    fetchedProduct = get(id);
    var data = ProductsRepository.data.ToList();
    data.Remove(fetchedProduct);
    ProductsRepository.data = data;
  }
          
  public static IEnumerable<Product> get()
  {
   return _data;
  }

  public static Product get(string name)
  { 

   if (_data == null || _data.ToList().Count == 0)
      throw new NotFoundException();

   var product = _data.FirstOrDefault(x => x.Name == name);

   return get(product.Id);

  }

  public static Product get(int id)
  {

   if (_data == null || _data.ToList().Count == 0)
    throw new NotFoundException();

    var product = _data.FirstOrDefault(x => x.Id == id);

    if (product == null)
       throw new NotFoundException();

    return product;
  }

  public static IEnumerable<Product> data
  {
   get
   { 
    if (_data == null)
    {
     _data = new List<Product>
     {
      new Product() { Id = 1, Name = "Gizmo 1", Price = 1.99M },
      new Product() { Id = 2, Name = "Gizmo 2", Price = 2.99M },
      new Product() { Id = 3, Name = "Gizmo 3", Price = 3.99M }
     };
    }

    return _data;
   }
   set
   {
    _data = value;
   }
  }

  public static void add(Product product)
  {
   var existingProduct = false;
   Product fetchedProduct;

   if (product.Id != 0)
   {
    throw new 
    Exception(@"Posted products cannot contain an id");
   }

   try
   {
    fetchedProduct = get(product.Name);
    existingProduct = true;
   }
   catch (Exception)
   {
    //this is actually good that we are here. Means we didn't 
    //find an existing product so it is OK to insert;
    
    if (ProductsRepository.data.ToList().Count == 0)
       {
        product.Id = 1;  
       }
     else
    {
     product.Id = ProductsRepository.data.Select(x => x.Id).Max() + 1;
    }
    
    var data = ProductsRepository.data.ToList();
    data.Add(product);
    ProductsRepository.data = data;
   }

   if (existingProduct)
   {
    throw new 
    Exception(@"The product name you are attempting to insert already exists.");
   }
  }

  public static void update(Product product)
  {
    Product existingProduct = get(product.Id);
    existingProduct.Name = product.Name;
    existingProduct.Price = product.Price;
   }
  }


 }

 public class NotFoundException : Exception
 {
  public NotFoundException() : base("Product not found")
  {
  }

}