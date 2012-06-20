using System;
using System.Configuration;
using System.Linq;
using System.Net;
using NUnit.Framework;
using Serializer;

namespace WebApiTest
{
 [TestFixture]
 public class Tests
  {
  private readonly string restService = ConfigurationManager.AppSettings["restService"];
  private readonly string apiPath = ConfigurationManager.AppSettings["apiPath"];
  private readonly HttpHelpers httpHelpers = new HttpHelpers();

  [SetUp]
  public void TestSetup()
  {
   httpHelpers.HttpInvoke(SupportedHttpMethods.DELETE, string.Format("{0}{1}", restService, apiPath));
  }

  [Test]
  public void TestPostProduct()
  {
   var newContent = "{\"Id\":0,\"Name\":\"Gizmo 4\",\"Price\":99.99}";
   var expected = "{\"Id\":4,\"Name\":\"Gizmo 4\",\"Price\":99.99}";

   //verify the product to be added does not already exist.
   var response = httpHelpers.GetHttpResponseMessage(SupportedHttpMethods.GET,
    string.Format("{0}{1}4", restService, apiPath));
   Assert.IsFalse(response.IsSuccessStatusCode);

   //add the new product
   httpHelpers.HttpInvoke(SupportedHttpMethods.POST, string.Format("{0}{1}", restService, apiPath), newContent);
    
   //verify it was added
   var actual = httpHelpers.GetHttpContent(string.Format("{0}{1}4", restService, apiPath));
    
   Assert.AreEqual(expected, actual);
  }

  [Test]
  public void TestDeleteProduct()
  {
   var response = httpHelpers.GetHttpResponseMessage(SupportedHttpMethods.DELETE,
    string.Format("{0}{1}1", restService, apiPath));
   Assert.IsTrue(response.IsSuccessStatusCode);

   response = httpHelpers.GetHttpResponseMessage(SupportedHttpMethods.GET,
    string.Format("{0}{1}1", restService, apiPath));
   Assert.IsFalse(response.IsSuccessStatusCode);
  }
         
  [Test]
  public void TestPutProduct()
  {
   var oldContent = "{\"Id\":1,\"Name\":\"Gizmo 1\",\"Price\":1.99}";
   var newContent = "{\"Id\":1,\"Name\":\"The New Title\",\"Price\":99.99}";
             
   //Verify the existing state of product 1
   var actual = httpHelpers.GetHttpContent(string.Format("{0}{1}1", restService, apiPath));
   Assert.AreEqual(oldContent, actual);

   //update product 1
   var response = httpHelpers.GetHttpResponseMessage(SupportedHttpMethods.PUT,
    string.Format("{0}{1}", restService, apiPath), newContent);

   //verify status code
   Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

   //Verify product 1 has been updated.
   actual = httpHelpers.GetHttpContent(string.Format("{0}{1}1", restService, apiPath));
   Assert.AreEqual(newContent, actual);
  }

  [Test]
  public void TestGetProduct()
  {
   var expected = "{\"Id\":1,\"Name\":\"Gizmo 1\",\"Price\":1.99}";
   var actual = httpHelpers.GetHttpContent(string.Format("{0}{1}1", restService, apiPath)); 

   Assert.AreEqual(expected, actual);
  }

  [Test]
  public void TestGetProducts()
  {
   var expected = "[{\"Id\":1,\"Name\":\"Gizmo 1\",\"Price\":1.99},{\"Id\":2,\"Name\":\"Gizmo 2\",\"Price\":2.99},{\"Id\":3,\"Name\":\"Gizmo 3\",\"Price\":3.99}]";

   var actual = httpHelpers.GetHttpContent(string.Format("{0}{1}", restService, apiPath)); 
      
   Assert.AreEqual(expected, actual);
  }
 }
}