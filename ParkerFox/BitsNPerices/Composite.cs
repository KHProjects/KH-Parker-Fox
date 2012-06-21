using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsNPerices
{
    public class LoanApplicationClient
    {
        public void ApplyForLoan()
        {
            ILoanApplicationStage loanApplication = LoanApplicationWorkflowFactory.CreateWorkflow();

            LoanApplicationRequest request = new LoanApplicationRequest
            {
                FirstName = "Dean",
                LoanAmount = 999
            };

            bool isApproved = loanApplication.Process(request);
        }
    }

    public class LoanApplicationRequest
    {
        private List<string> _failedReasons = new List<string>();

        public string FirstName { get; set; }
        public decimal LoanAmount { get; set; }

        public void AddFailReason(string reason)
        {
            _failedReasons.Add(reason);
        }
    }

    public class LoanApplicationWorkflowFactory
    {
        public static ILoanApplicationStage CreateWorkflow()
        {
            return new ChainedStages(new List<ILoanApplicationStage>
            {
                new ValidateDataStage(),
                new LoanAmountVerificationStage(),
                new IndentityCheckStage()
            });
        }
    }

    public interface ILoanApplicationStage
    {
        bool Process(LoanApplicationRequest workflow);
    }

    public class ChainedStages : ILoanApplicationStage
    {
        private List<ILoanApplicationStage> _stages;

        public ChainedStages(List<ILoanApplicationStage> stages)
        {
            _stages = stages;
        }

        public bool Process(LoanApplicationRequest workflow)
        {
            foreach (var stage in _stages)
            {
                if (!stage.Process(workflow))
                    return false;
            }
            return true;
        }
    }

    public class ValidateDataStage : ILoanApplicationStage
    {
        public bool Process(LoanApplicationRequest workflow)
        {
            if (String.IsNullOrWhiteSpace(workflow.FirstName))
            {
                workflow.AddFailReason("please supply ur name");
                return false;
            }
            return true;
        }
    }

    public class LoanAmountVerificationStage : ILoanApplicationStage
    {
        public bool Process(LoanApplicationRequest workflow)
        {
            if (workflow.LoanAmount > 10000)
            {
                workflow.AddFailReason("you can not have that much money");
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class IndentityCheckStage : ILoanApplicationStage
    {
        public bool Process(LoanApplicationRequest workflow)
        {
            if (workflow.FirstName.Equals("Dean"))
            {
                workflow.AddFailReason("HAHA");
                return false;
            }
            return true;
        }
    }
}
