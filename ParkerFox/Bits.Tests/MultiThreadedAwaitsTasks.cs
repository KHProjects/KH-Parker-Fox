using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bits.Tests
{
    [TestClass]
    public class MultiThreadedAwaitsTasks
    {
        private delegate void MyMethodPointer(); //--delegate keyword causes compiler to generate a class, this class automatically support multi-threading

        [TestMethod]
        public void MultiThreadedUsingDelegates()
        {
            MyMethodPointer pointer = SomeMethodToBeRunOnAnotherThread;

            //--call the delegate asyncronously (on a new thread). we need to pass the method pointer in the catch-all value "bag"
            pointer.BeginInvoke(SomeCallbackMethod, pointer);
        }

        [TestMethod]
        public void MultiThreadedWithTask()
        {
            Task.Run(()=>
                {
                    Debug.WriteLine("This is running in thread:{0}", Thread.CurrentThread.Name);
                });
        }


        #region Helper classes and methods
        public void SomeMethodToBeRunOnAnotherThread()
        {
            Debug.WriteLine("This is running in thread:{0}", Thread.CurrentThread.Name);
        }
        public void SomeCallbackMethod(IAsyncResult asyncResult)
        {
            //--we need to pull out the method pointer from the catch-all value "bag"
            MyMethodPointer pointer = asyncResult.AsyncState as MyMethodPointer;

            //--we need the reference to this guy so we can basically call the EndAsync
            pointer.EndInvoke(asyncResult);
        }
        #endregion
    }
}
