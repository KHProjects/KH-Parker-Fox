using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsNPerices
{

  //Template pattern (also look at strategy pattern)
  public abstract class LoanApplication
  {

    public void ApplyForLoan(LoanRequest loanRequest)
    {
      ValidateInput(loanRequest);
      ApplyPromotion(loanRequest);
    }

    public void ValidateInput(LoanRequest loanRequest)
    {
      if (string.IsNullOrWhiteSpace(loanRequest.EmailAddress))
        throw new InvalidOperationException();
    }

    //extension point to the users of this class:
    public abstract void ApplyPromotion(LoanRequest loanRequest);

  }

  public class LoanRequest
  {

    public int LoanRequestID { get; set; }
    public string EmailAddress { get; set; }
    public int AmountRequested { get; set; }

  }

  public class MEMLoanApplication : LoanApplication
  {

    public override void ApplyPromotion(LoanRequest loanRequest)
    {
      loanRequest.AmountRequested *= 10;
    }

  }

  public class PDUKExpressLoanApplication : LoanApplication
  {

    public override void ApplyPromotion(LoanRequest loanRequest)
    {
      loanRequest.AmountRequested *= 5;
    }

  }

  public class LoanApplicationController
  {

    private LoanApplication loanApplication;

    public LoanApplicationController()
    {
      //ninject this
      loanApplication = new MEMLoanApplication();
    }

    public void Apply()
    {

      LoanRequest loanRequest = new LoanRequest()
      {
          LoanRequestID = 1,
          EmailAddress = "someone@something.com",
          AmountRequested = 500
      };

      loanApplication.ApplyForLoan(loanRequest);
    }
  }







}
