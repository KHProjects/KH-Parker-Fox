using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Serializer;
namespace Data
{
 public class ProductsRepository
 {
  private readonly string restService = ConfigurationManager.AppSettings["restService"];
  private readonly string apiPath = ConfigurationManager.AppSettings["apiPath"];
  readonly JsonNetSerialization serializer = new JsonNetSerialization();
  readonly HttpHelpers httpHelpers = new HttpHelpers();

  public Product New()
  {
   return new Product();
  }

  public void Update(Product product)
  {
   httpHelpers.HttpInvoke(SupportedHttpMethods.PUT, string.Format("{0}/{1}", restService, apiPath),
    serializer.Serialize<Product>(product));
  }
  
  public List<Product> Get()
  {
   var content = httpHelpers.GetHttpContent(string.Format("{0}/{1}", restService, apiPath));
   return serializer.DeSerialize<List<Product>>(content) as List<Product>;
  }

  
  public Product Get(string name) {
  
     var url = string.Format("{0}/{1}?$filter=name eq'{2}'", restService, apiPath, name);
     var content = httpHelpers.GetHttpContent(url);
     var products = serializer.DeSerialize<IList<Product>>(content) as IList<Product>;
     return products[0];
  }
  
  public Product Get(int id)
  {
   var content = httpHelpers.GetHttpContent(string.Format("{0}/{1}{2}", restService, apiPath, id));
   return serializer.DeSerialize<Product>(content) as Product;
  }

  public void Create(Product product)
  {
   httpHelpers.HttpInvoke(SupportedHttpMethods.POST, string.Format("{0}{1}", restService, apiPath),
    serializer.Serialize<Product>(product));
  }
  
  public void Delete(int id)
  {
   httpHelpers.HttpInvoke(SupportedHttpMethods.DELETE, string.Format("{0}/{1}{2}", restService, apiPath, id));
  }
 }
}