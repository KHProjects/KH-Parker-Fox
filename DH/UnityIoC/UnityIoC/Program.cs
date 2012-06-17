using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace UnityIoC
{
  class Program
  {
    static void Main(string[] args)
    {
      var container = new UnityContainer();

      container.RegisterType<ICreditCard, MasterCard>();
      //container.RegisterType<ICreditCard, MasterCard>(new InjectionProperty("ChargeCount", 5));
      container.RegisterType<ICreditCard, Visa>(new InjectionProperty("ChargeCount", 5));


      var shopper = container.Resolve<Shopper>();
      //var shopper = container.Resolve<Shopper>(new ParameterOverride("creditCard", new Visa()));

      shopper.Charge();

      Console.Read();
    
    }
  }

  public class Visa : ICreditCard
  {
    public string Charge()
    {
      return "Visa... Visa";
    }

    public int ChargeCount { get; set; }

  }

  public class MasterCard : ICreditCard
  {
    public string Charge()
    {
      ChargeCount++;
      return "Charging with MasterCard!";
    }

    public int ChargeCount { get; set; }

  }

  public interface ICreditCard
  {
    string Charge();
    int ChargeCount { get; }
  }

  public class Shopper
  {
    private readonly ICreditCard creditCard;

    public Shopper(ICreditCard creditCard)
    {
      this.creditCard = creditCard;
    }

    public int ChargesForCurrentCard
    { 
      get { return creditCard.ChargeCount; } 
    }

    public void Charge()
    {
      Console.WriteLine(creditCard.Charge());
    }
  }



}
