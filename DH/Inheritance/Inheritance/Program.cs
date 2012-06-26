using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            IAccount account = new CurrentAccount();
            account.Payment(200);
            account.Withdraw(60);


            CurrentAccount myAccount = new ChildAccount();
            myAccount.Withdraw(5);

        }
    }

    public interface IAccount
    {
        bool Payment(double payment);
        double GetBalance();
        bool Withdraw(double withdrawal);
    }

    public class CurrentAccount : IAccount
    {
        private double _balance { get; set; }

        public double GetBalance()
        {
            return _balance;
        }

        public bool Payment(double payment)
        {
            _balance += payment;
            return true;
        }
    
        public virtual bool  Withdraw(double withdrawal)
        {
         	if(withdrawal <= _balance && withdrawal <=250)
                return true;
            return false;
        }
    }

    public class ChildAccount : CurrentAccount
    {
        public override bool Withdraw(double withdrawal)
        {
            if(withdrawal <= 10)
                return base.Withdraw(withdrawal);
            return false;
        }
    }

}
