using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsNPerices
{
    /// <summary>
    /// Strategy is used when the whole algorithm is replaced template is used when only parts of the alo
    /// </summary>

    public class LoanPaymentProcessorService
    {
        public void GetPayments()
        {
            Loan loan = new Loan { Amount = 10000, DueDate = DateTime.Now };
            
            decimal newPayment = loan.GetNextPaymentAmount();
        }
    }

    public class Loan
    {
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }

        public IPaymentStategy GetPaymentStategy()
        {
            if (DateTime.Now.Subtract(DueDate).Days < 10)
            {
                return new ReducePrincipalStrategy();
            }
            else
            {
                return new InterestOnlyPaymentStategy();
            }
        }

        public decimal GetNextPaymentAmount()
        {
            return GetPaymentStategy().GetAmount(this);
        }
    }

    public interface IPaymentStategy
    {
        decimal GetAmount(Loan loan);
    }

    public class InterestOnlyPaymentStategy : IPaymentStategy
    {
        public decimal GetAmount(Loan loan)
        {
            return loan.Amount * 0.10m;
        }
    }

    public class ReducePrincipalStrategy : IPaymentStategy
    {
        public decimal GetAmount(Loan loan)
        {
            return (loan.Amount * 0.10m) + 100m;
        }
    }
}