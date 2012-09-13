using System;
using System.Collections.Generic;
using System.Linq;
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

            action(1234);
            string output = func("input");
            bool isValid = predicate("input");
        }

        [TestMethod]
        public void AnonymousAndLambda()
        {
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
                    string message = "this is an Action<T> delegate";

                }).Start();
        }

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
    }
}
