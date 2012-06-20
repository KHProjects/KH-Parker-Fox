using System;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Serializer;

namespace Serializer
{
 public enum SupportedHttpMethods
 {
  GET,
  POST,
  PUT,
  DELETE
 }

 public class HttpClass : IDisposable
 {
  Uri _uri;
  HttpMethod _httpMethod;
  StringContent _content;
  HttpClient _httpClient = new HttpClient();
  Action _action;
  HttpResponseMessage _httpResponseMessage;

  public HttpClass(SupportedHttpMethods httpMethod, string uri, string content) : this(httpMethod,uri)
  {
   if (httpMethod == SupportedHttpMethods.POST || httpMethod == SupportedHttpMethods.PUT)
   {
    JObject.Parse(content);
    _content = new StringContent(content);
    _content.Headers.ContentType = new MediaTypeHeaderValue("text/json");
   }
   else
   {
    throw new InvalidHttpMethodContentCombinationException();
   }
  }

  public HttpClass(SupportedHttpMethods httpMethod, string uri)
  {
   _uri = new Uri(uri);
   _httpMethod = new HttpMethod(httpMethod.ToString());

   switch (httpMethod)
   {
    case SupportedHttpMethods.GET:
     _action = get;
     break;
    case SupportedHttpMethods.POST:
     _action = post;
     break;
    case SupportedHttpMethods.PUT:
     _action = put;
     break;
    case SupportedHttpMethods.DELETE:
     _action = delete;
     break;
    default:
     throw new InvalidHttpMethodException();
   }
  }

  public void Dispose()
  {
  }

  public HttpResponseMessage GetHttpResponseMessage()
  {
   return _httpResponseMessage;
  }

  public string GetResponseContent()
  {
   if (_httpMethod.Method == SupportedHttpMethods.GET.ToString())
    return _httpResponseMessage.Content.ReadAsStringAsync().Result;

   return null;
  }

  public void Invoke()
  {
   _action.Invoke();       
  }

  void delete()
  {
   _httpResponseMessage = _httpClient.DeleteAsync(_uri).Result;
  }

  void get()
  {
   _httpResponseMessage = _httpClient.GetAsync(_uri).Result;
  }

  void post()
  {
   _httpResponseMessage = _httpClient.PostAsync(_uri, _content).Result;
  }

  void put()
  {
   _httpResponseMessage = _httpClient.PutAsync(_uri, _content).Result;
  }
 }

 public class InvalidHttpMethodContentCombinationException : Exception
 {
  public InvalidHttpMethodContentCombinationException() : base("When specifying content, either a POST or PUT must be used")
  {
  }
 }

 public class InvalidHttpMethodException : Exception
 {
  public InvalidHttpMethodException() : base("Only PUT, POST, GET and DELETE Methods are supported")
  {
  }
 }
}