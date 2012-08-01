using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abstract
{
  class Program
  {
    static void Main(string[] args)
    {
      Account customerAccount = new CustomerAccount();
      Account childAccount = new BabyAccount();
      
      Console.WriteLine(customerAccount.RudeLetterString());
      Console.WriteLine(childAccount.RudeLetterString());
      Console.ReadLine();
    }
  }


  public interface IAccount
  {
    void PayInFunds(decimal amount);
    bool WithdrawFunds(decimal amount);
    decimal GetBalance();
    string RudeLetterString();
  }


  public abstract class Account : IAccount
  {
    private decimal _balance = 0;

    public abstract string RudeLetterString();

    public virtual bool WithdrawFunds(decimal amount)
    {
      if (_balance < amount)
        return false;
      _balance -= amount;
      return true;
    }

    public virtual decimal GetBalance()
    {
      return _balance;
    }

    public void PayInFunds(decimal amount)
    {
      _balance += amount;
    }
  }

  public class CustomerAccount : Account 
  { 
    public override string RudeLetterString() 
    { 
      return "You are overdrawn"; 
    } 
  }

  public class BabyAccount : Account
  {
    public override bool WithdrawFunds(decimal amount)
    {
      if (amount > 10)
      {
        return false;
      }
      return base.WithdrawFunds(amount);
    }

    public override string RudeLetterString()
    {
      return "Tell daddy you are overdrawn";
    }
  }


}
