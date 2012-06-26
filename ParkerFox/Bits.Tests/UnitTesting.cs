using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitsNPerices.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Bits.Tests
{
    [TestClass]  //TestFixture
    public class UnitTesting
    {
        [TestMethod] //Test
        public void CanGetCustomer()
        {
            //arrange
            var sessionContext = MockRepository.GenerateMock<ISessionContext>();
            var customerDataAccess = MockRepository.GenerateMock<ICustomerDataAccess>();

            customerDataAccess.Expect(x => x.GetById(Arg<int>.Is.Anything)).Return(new Customer
            {
                Name="bob"
            }).IgnoreArguments();

            //act
            CustomerServices customerServices = new CustomerServices(sessionContext, customerDataAccess);
            var customer = customerServices.GetCurrent();
            
            //assert
            Assert.IsTrue(customer.Name == "bob");

            Assert.IsTrue(customerServices.MyInternalMessage == "test tickle");
        }
    }

    public class TestSessionContent : ISessionContext
    {
        public int GetCurrentLoggedInCustomerId()
        {
            return 1;
        }
    }

    public class TestCustomerDataAccess : ICustomerDataAccess
    {

        public Customer GetById(int customerId)
        {
            return new Customer { CustomerId = 2 };
        }
    }


}
