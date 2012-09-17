using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitsNPerices;
using System.Diagnostics;

namespace Bits.Tests
{
    [TestClass]
    public class Delegates
    {
        private delegate void DelegateDefinition(int parameterOne);
        private delegate string MyOtherDelegate(int p);

        [TestMethod]
        public void Basics()
        {
            DelegateDefinition one = new DelegateDefinition(SomeArbitraryMethod);
            one += SomeOtherArbitraryMethod;
            one(1000);           
        }

        [TestMethod]
        public void PassDelegate()
        {
            var delegates = new DelegatesLamda();
            var methodDelegate = new DelegatesLamda.MethodWithOneParameter(SomeArbitraryMethod);
            var functionDelegate = new DelegatesLamda.FunctionWithOneParameter(FunctionOne);

            var multiCastDelegate = new DelegatesLamda.MethodWithOneParameter(SomeArbitraryMethod);
            multiCastDelegate += SomeOtherArbitraryMethod;
            multiCastDelegate += DelegatesLamda.StaticMethodOne;

            delegates.Call(methodDelegate);
            delegates.Call(functionDelegate);
            delegates.Call(multiCastDelegate);
        }

        [TestMethod]
        public void BuiltInDelegates()
        {
            //takes a parameter, returns void         delegate void Action<T1>(T1 parameter1);
            Action<int> action = SomeArbitraryMethod;            
            //takes 0 or more params and returns the final generic type parameter
            Func<string, string> func = FunctionOne;
            //returns a bool and accepts the only type parameter 
            Predicate<string> predicate = SomeCondition;

            Action<Order> orderAction = (order) =>
                {
                    order.Total += 10;
                };

            Func<Order, string> orderFunction = (order) =>
                {
                    decimal total = order.Total;
                    return String.Format("Order {0} total is {1}", order.OrderId, total);
                };
        }

        [TestMethod]
        public void AnonymousAndLambda()
        {
            // this symbol '=>' is called the lambda operator, when reading code you can use the words 'goes to'
            // when you see this symbol.
            // var myMethod = () => Debug.WriteLine();
            // "my method is a parameterless method that goes to debug write line"

            Action<int> beforeLambda = delegate(int p) { Debug.WriteLine("Your passed {0}", p); };
            Action<int> withLambda = param => Debug.WriteLine("bla bla");

            Func<string> lambdaNoPars = () => "this is auto return value";

            Func<int, int, string> complexMethod = (x, y) =>
                {
                    string result = String.Format("{0} X {1} = {2}", x, y, x*y);
                    return result;
                };
        }

        [TestMethod]
        public void SomeExamples()
        {
            new List<int>().Sort((x, y) => x.CompareTo(y));

            new Task(()=>
                {
                    string message = "this is an Action<T> delegate, run on seperate thread";

                }).Start();


            
            Order orderUpForDiscount = new Order {Total = 100};

            Action<Order> discountAction = new OrderService().GetCurrentDiscountingAction();

            orderUpForDiscount.ApplyDiscount(discountAction);
        }

        [TestMethod]
        public void Advanced()
        {
            Action<int> expression = (i) => Debug.WriteLine("expression lambda are one line lambdas");
            Action<int> statement = (i) =>
                {
                    string msg = "statement lambds are multi-line";
                    Debug.WriteLine(msg);
                };

            Expression<Func<int, bool>> expressionTree = i => i < 5;
        }

        #region Helper methods
        private void SomeArbitraryMethod(int param)
        {
            Debug.WriteLine("Your called some arb method with param: {0}", param);
        }

        private void SomeOtherArbitraryMethod(int param)
        {
            Debug.WriteLine("Your called some other arb method with param: {0}", param);
        }

        private string FunctionOne(string input)
        {
            return String.Format("FunctionOne called with input: {0}", input);
        }

        private bool SomeCondition(string input)
        {
            return false;
        }

        private static void SomeStaticArbitraryMethod(int param)
        {
            Debug.WriteLine("Your called some other arb method with param: {0}", param);
        }
        #endregion

        #region Helper Classes
        private class Order
        {
            public int OrderId { get; set; }
            public decimal Total { get; set; }

            public void ApplyDiscount(Action<Order> discount)
            {
                discount(this);
            }
        }
        private class OrderService
        {
            //this discount thru delegate is a way to implement Strategy Pattern.... http://stackoverflow.com/questions/984050/c-sharp-strategy-design-pattern-by-delegate-vs-oop
            public Action<Order> GetCurrentDiscountingAction()
            {
                Action<Order> discountAction;

                if (DateTime.Now.Day % 2 == 0)
                {
                    discountAction = (order) =>
                        {
                            if (order.Total > 50)
                                order.Total -= 10;
                        };
                }
                else
                {
                    discountAction = (order) =>
                        {
                            if (order.Total > 30)
                                order.Total -= 5;
                        };
                }

                return discountAction;
            }
        }
        #endregion
    }
}
