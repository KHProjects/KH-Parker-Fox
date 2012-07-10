using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BitsNPerices
{
    public class Person
    {
        public string Name { get; set; }
    }

    public class Asyncronous
    {
        delegate Person AsyncMethod();
        private AsyncMethod _myOtherThread;

        public void Run()
        {            
            _myOtherThread = new AsyncMethod(SomeMethod);

            _myOtherThread.BeginInvoke(CallBackMethod, null);            
        }

        public void RunTask()
        {
            Task task = new Task(() => 
            { 
                Console.WriteLine("task with lambda"); 
            });
            task.Start();
        }

        public void MyAction()
        {
            Console.WriteLine("task");
        }

        public void CallBackMethod(IAsyncResult result)
        {
            Person person = _myOtherThread.EndInvoke(result);
            Console.WriteLine(String.Format("you got person {0}", person.Name));
        }

        public Person SomeMethod()
        {   
            return new Person { Name = "bob" };
        }
    }

    public class FuckinWithThreads
    {
        private int someValue = 1;
        private static object freddy = new object();

        public void Run()
        {
            Thread thread = new Thread(SomeAsyncMethod);
            thread.Name = "thread one";
            thread.Start();

            Thread thread2 = new Thread(SomeAsyncMethod);
            thread2.Name = "thread two";
            thread2.Start();

            Thread thread3 = new Thread(SomeAsyncMethod);
            thread3.Name = "thread three";
            thread3.Start();
        }

        public void SomeAsyncMethod()
        {
            for (int i = 0; i < 1000; i++)
            {
                lock (freddy)
                {
                    someValue += 1;
                    Console.WriteLine("{0} set value to {0}", Thread.CurrentThread.Name, someValue);
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                }
            }            
        }
    }

}
