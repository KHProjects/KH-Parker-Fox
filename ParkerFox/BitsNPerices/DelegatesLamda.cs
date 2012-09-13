using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsNPerices
{
    /// <summary>
    /// http://codebetter.com/karlseguin/2008/11/27/back-to-basics-delegates-anonymous-methods-and-lambda-expressions/
    /// </summary>
    public class DelegatesLamda
    {
        public delegate void MethodWithOneParameter(int parameterOne);
        public delegate string FunctionWithOneParameter(string input);


        public void Call(MethodWithOneParameter method)
        {
            method(10);
        }

        public void Call(FunctionWithOneParameter function)
        {
            string output = function("some input");
            Debug.WriteLine(output);
        }

        public void MethodOne(int param)
        {
            Debug.WriteLine("Method one called with {0}", param);
        }

        public static void StaticMethodOne(int param)
        {
            Debug.WriteLine("Static method one called with {0}", param);
        }
    }
}
