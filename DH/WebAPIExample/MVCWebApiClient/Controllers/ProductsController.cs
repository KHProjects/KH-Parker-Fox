using System;
using System.Linq;
using System.Web.Mvc;
using MVCWebApiClient.SignalR;
using SignalR;
using Data;


namespace MVCWebApiClient.Controllers
{
 public class ProductsController : Controller
 {
  //
  // GET: /Products/
  ProductsRepository _productRepository;

  public ProductsController(ProductsRepository productRepository)
  {
   _productRepository = productRepository;
  }

  public ActionResult Index()
  {
   var product = _productRepository.Get();

   return View(product);
  }

  //
  // GET: /Products/Details/5

  public ActionResult Details(int id)
  {
   return View(_productRepository.Get(id));
  }

  //
  // GET: /Products/Create

  public ActionResult Create()
  {
   return View(_productRepository.New());
  }

  //
  // POST: /Products/Create

  [HttpPost]
  public ActionResult Create(Product model)
  {
   _productRepository.Create(model);
   SendTransaction(_productRepository.Get(model.Name).Id, "Create");

              
   return RedirectToAction("Index");
  }

  //
  // GET: /Products/Edit/5

  public ActionResult Edit(int id)
  {
   return View(_productRepository.Get(id));
  }

  //
  // POST: /Products/Edit/5

  [HttpPost]
  [ValidationFilter]
  public ActionResult Edit(Product model)
  {
   try
   {
    _productRepository.Update(model);
    SendTransaction(model.Id,"Edit");

    return RedirectToAction("Index");
   }
   catch
   {
    return View();
   }
  }

  //
  // GET: /Products/Delete/5

  public ActionResult Delete(int id)
  {
   return View(_productRepository.Get(id));
  }

  //
  // POST: /Products/Delete/5

  [HttpPost]
  public ActionResult Delete(int id, FormCollection collection)
  {
   try
   {

    _productRepository.Delete(id);
    SendTransaction(id, "Delete");

    return RedirectToAction("Index");
   }
   catch
   {
    return View();
   }
  }


  void SendTransaction(int id, string type) {


   var clients = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>().Clients;
   clients.sendMessage(string.Format("Product ID: {0}, {1} ", id,type));  

  }

 }
}