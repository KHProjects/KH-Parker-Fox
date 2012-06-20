using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Serializer;
using StructureMap;
using StructureMap.Configuration.DSL;
using Data;

namespace MVCWebApiClient
{
 public class StructureMapContainerSetup
 {
  public static void SetUp()
  {
   ObjectFactory.Initialize(x => x.AddRegistry<StructureMapRegistry>());
   DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
  }
 }

 public class StructureMapRegistry : Registry
 {
  public StructureMapRegistry()
  {
   For<ISerialization>().Use<JsonNetSerialization>();
   For<ProductsRepository>().Use<ProductsRepository>();
   For<ProductValidator>().Use<ProductValidator>();
  }
 }

 public class StructureMapDependencyResolver : IDependencyResolver
 {
  private readonly IContainer _container;

  public StructureMapDependencyResolver(IContainer container)
  {
   _container = container;
  }



  public object GetService(string fullName){

    foreach(var item in _container.Model.AllInstances) {
    
       if (item.ConcreteType != null && item.ConcreteType.FullName == fullName)
          return GetService(item.ConcreteType.UnderlyingSystemType);
    }


    return null;
  
  //linq not working.
  //  var service = _container.Model.AllInstances.ToList().Where(x=> x.ConcreteType.FullName == fullName).First();
  
  
  }

  public object GetService(System.Type serviceType)
  {

   object instance = _container.TryGetInstance(serviceType);

   if (instance == null && !serviceType.IsAbstract)
   {
    _container.Configure(c => c.AddType(serviceType, serviceType));
    instance = _container.TryGetInstance(serviceType);
   }

   return instance;
  }

  public IEnumerable<object> GetServices(Type serviceType)
  {
   foreach (var component in _container.GetAllInstances(serviceType))
   {
    yield return component;
   }
  }
 }
}