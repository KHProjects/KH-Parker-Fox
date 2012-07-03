using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsNPerices.Dean
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IAccount customerAccount = new CustomerAccount();
            IAccount childAccount = new BabyAccount();

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

        public Account(ICanWithdrawMoney canWithdrawMoney)
        {
            CanWithdrawMoney = canWithdrawMoney;
        }

        public ICanWithdrawMoney CanWithdrawMoney { get; private set; }

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
        public CustomerAccount()
            : base(new MediumWithdrawnAmount())
        {

        }

        public override string RudeLetterString()
        {
            return "You are overdrawn";
        }
    }

    public class BabyAccount : Account
    {
        public BabyAccount()
            : base(new SmallWithrawAmount())
        {
        }

        public override bool WithdrawFunds(decimal amount)
        {
            #region Composition

            if (CanWithdrawMoney.CanWithDraw(amount))
                return base.WithdrawFunds(amount);

            return false;

            #endregion

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


    #region composition

    public interface ICanWithdrawMoney
    {
        bool CanWithDraw(decimal amount);
    }

    public class SmallWithrawAmount : ICanWithdrawMoney
    {
        public bool CanWithDraw(decimal amount)
        {
            return amount < 10;
        }
    }

    public class MediumWithdrawnAmount : ICanWithdrawMoney
    {
        public bool CanWithDraw(decimal amount)
        {
            return amount < 100;
        }
    }



    #endregion

}
