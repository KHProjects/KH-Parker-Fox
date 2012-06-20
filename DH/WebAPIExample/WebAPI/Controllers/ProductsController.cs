using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
 public class ProductsController : ApiController
 {

 [Queryable]
  public IQueryable<Product> GetProducts()
  {
   return ProductsRepository.data.AsQueryable();
  }

  public Product GetProduct(int id)
  {
   
   try
   {

    return ProductsRepository.get(id);

   }
   catch (NotFoundException)
   {
        throw new HttpResponseException(
           new HttpResponseMessage()
           {
           StatusCode= System.Net.HttpStatusCode.NotFound
           });
   }
  }

  [HttpDelete]
  public void ResetProducts()
  {
   ProductsRepository.reset();
  }
        
  public void DeleteProduct(int id)
  {
   
   try
   {
    ProductsRepository.delete(id);
    
   }
   catch (NotFoundException)
   {
    throw new HttpResponseException(
       new HttpResponseMessage()
       {
        StatusCode = System.Net.HttpStatusCode.NotFound
       });
   }
  }

  public void PutProduct(Product product)
  {
   ProductsRepository.update(product);
  }

  public void PostProduct(Product product)
  {
   ProductsRepository.add(product);
  }
 }
}