using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Modules;

namespace NinjectIoC
{
  class Program
  {
    static void Main(string[] args)
    {

      //container is called kernal (because it represents the kernal / core of the application

      //var kernal = new StandardKernel();
      //kernal.Bind<ICreditCard>().To<MasterCard>();

      var kernal = new StandardKernel(new MyModule());
      //kernal.Rebind<ICreditCard>().To<MasterCard>();

      //dont have to register all the types.. ninject will automatically register concrete types so we can ask for any concrete type and ninject will know how to create it.. without us having to speciy it specificallly in the container.. makes it a little easier so we don't have to configure every single class that we are going to use.
      //(dont need to register shopper type because its automatic)
      //whenever we ask for an ICreditCard were going to get back a MasterCard.

      var shopper = kernal.Get<Shopper>();
      shopper.Charge();
      Console.WriteLine(shopper.ChargesForCurrentCard);

      var shopper2 = kernal.Get<Shopper>();
      shopper2.Charge();
      Console.WriteLine(shopper2.ChargesForCurrentCard);

      //Shopper shopper3 = new Shopper();
      //shopper3.Charge();
      //Console.WriteLine(shopper3.ChargesForCurrentCard);

      Console.Read();

    }

    public class MyModule : NinjectModule
    {
      public override void  Load()
      {
       	Kernel.Bind<ICreditCard>().To<TestCard>();
      }
    }

    public class Visa : ICreditCard
    {
      public int ChargeCount { get; set; }

      public string Charge()
      {
        return "Visa... Visa";
      }
    }

    public class MasterCard :ICreditCard
    {
      public int ChargeCount {get;set;}

      public string Charge()
      {
        ChargeCount++;
        return "Charging with the MasterCard!";
      }
    }

    public class TestCard : ICreditCard
    {
      public int ChargeCount { get; set; }

      public string Charge()
      {
        ChargeCount++;
        return "Charging with the TestCard!";
      }
    }

    public interface ICreditCard
    {
      string Charge();
      int ChargeCount { get; set; }
    }

    public class Shopper
    {
      private readonly ICreditCard creditCard;

      //uses constructor injection to take in the CreditCard
      public Shopper(ICreditCard creditCard)
      {
        this.creditCard = creditCard;
      }
      //charge should be spit into a seperate PaymentProcessor class if following the SOLID srp (single responsibility pattern) pattern?..
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
}
