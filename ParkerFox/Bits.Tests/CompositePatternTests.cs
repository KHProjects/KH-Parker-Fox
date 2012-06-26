using System;
using BitsNPerices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bits.Tests
{
    [TestClass]
    public class CompositePatternTests
    {
        [TestMethod]
        public void CanBeDENIED()
        {
            ILoanApplicationStage loanApplication = LoanApplicationWorkflowFactory.CreateWorkflow();
            
            LoanApplicationRequest request = new LoanApplicationRequest
            {
                FirstName = "Dean",
                LoanAmount = 999
            };

            bool isApproved = loanApplication.Process(request);

            Assert.IsFalse(isApproved, "Dean shouldn't be lent any money!!!");
        }
    }
}
