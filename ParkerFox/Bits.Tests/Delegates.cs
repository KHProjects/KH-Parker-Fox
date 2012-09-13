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

        [TestMethod]
        public void Basics()
        {
            DelegateDefinition one = new DelegateDefinition(SomeArbitraryMethod);
            one(10);

            DelegateDefinition two = SomeArbitraryMethod;
            two(20);

            DelegateDefinition staticMethod = Stat
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
            Action<int> action = SomeArbitraryMethod;
            Func<string, string> func = FunctionOne;
            Predicate<string> predicate = SomeCondition;

            action(1234);
            string output = func("input");
            bool isValid = predicate("input");
        }

        [TestMethod]
        public void Anonymous()
        {
            DelegatesLamda.MethodWithOneParameter methodWithOneParameter = x => Debug.WriteLine("called with {0}", x);
            DelegatesLamda.FunctionWithOneParameter functionWithOneParameter = input =>
                {
                    Debug.WriteLine("you call this method with {0}", input);
                    return "well done";
                };

            Action<DateTime> anonymousAction = (dateTime) => { };
            Func<string, string> anonymousFunction = (input) => { return String.Format("anonymous function with input: {0}", input); };
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
