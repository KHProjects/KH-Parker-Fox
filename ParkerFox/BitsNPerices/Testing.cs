using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsNPerices.Testing
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
    }

    public interface ISessionContext
    {
        int GetCurrentLoggedInCustomerId();
    }

    public class SessionContext : ISessionContext
    {
        public int GetCurrentLoggedInCustomerId()
        {
            return 1;
        }
    }

    public interface ICustomerServices
    {
        Customer GetCurrent();
    }

    public class CustomerServices : ICustomerServices
    {
        private ISessionContext _sessionContext;
        private ICustomerDataAccess _customerDataAccess;

        public CustomerServices(ISessionContext sessionContext, ICustomerDataAccess customerDataAccess)
        {
            _sessionContext = sessionContext;
            _customerDataAccess = customerDataAccess;
        }

        public Customer GetCurrent()
        {
            int customerId = _sessionContext.GetCurrentLoggedInCustomerId();
            return _customerDataAccess.GetById(customerId);
        }

        internal string MyInternalMessage
        {
            get { return "test tickle"; }
        }
    }

    public interface ICustomerDataAccess
    {
        Customer GetById(int customerId);
    }

    public class CustomerDataAccess : ICustomerDataAccess
    {
        public Customer GetById(int customerId)
        {
            return new Customer
            {
                CustomerId = customerId,
                Name = "Llama farmer"
            };
        }
    }

}
