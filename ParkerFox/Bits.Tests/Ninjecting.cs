using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bits.Tests
{
    [TestClass]
    public class Ninjecting
    {
        [TestMethod]
        public void Basics()
        {
            StandardKernel kernel = new StandardKernel();

            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IOrderSerivces>().To<OrderServices>();

            var orderServices = kernel.Get<IOrderSerivces>();

            var orders = orderServices.GetCurrent();
        }

        [TestMethod]
        public void NamedBinding()
        {
            StandardKernel kernel = new StandardKernel();

            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IOrderSerivces>().To<OrderServices>().Named("standard");
            kernel.Bind<IOrderSerivces>().To<PriorityOrderServices>().Named("priority");
            kernel.Load(new CustomModule());

            var orderServices = kernel.Get<IOrderSerivces>("standard");
            var priorityOrderServices = kernel.Get<IOrderSerivces>("priority");

            Assert.IsTrue(orderServices is OrderServices);
            Assert.IsTrue(priorityOrderServices is PriorityOrderServices);
        }

        [TestMethod]
        public void Interception()
        {
            StandardKernel kernel = new StandardKernel();

            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IOrderSerivces>().To<OrderServices>();

            
        }

        #region Helper Classes
        private class Order{}

        private interface IOrderRepository
        {
            IEnumerable<Order> GetAll();
        }

        private class OrderRepository : IOrderRepository
        {
            public IEnumerable<Order> GetAll()
            {
                return new List<Order>
                    {
                        new Order{}
                    };
            }
        }

        private interface IOrderSerivces
        {
            IEnumerable<Order> GetCurrent();
        }

        private class OrderServices : IOrderSerivces
        {
            private readonly IOrderRepository _orderRepository;

            public OrderServices(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public IEnumerable<Order> GetCurrent()
            {
                return _orderRepository.GetAll();
            }
        }

        private class PriorityOrderServices : IOrderSerivces
        {
            private readonly IOrderRepository _orderRepository;

            public PriorityOrderServices(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public IEnumerable<Order> GetCurrent()
            {
                return _orderRepository.GetAll();
            }
        }

        #endregion

        private class CustomModule : NinjectModule
        {
            public override void Load()
            {
                Kernel.Bind<IOrderSerivces>().To<OrderServices>().Named("fromModule");
            }
        }

        private class Intercept : InterceptionModule
        {
            public override void Load()
            {
                
            }
        }

        private class DebugInterceptor : SimpleInterceptor
        {
            protected override void BeforeInvoke(IInvocation invocation)
            {
                Debug.WriteLine("intercepted {0}", invocation.ToString());
                base.BeforeInvoke(invocation);
            }
        }
    }
}
