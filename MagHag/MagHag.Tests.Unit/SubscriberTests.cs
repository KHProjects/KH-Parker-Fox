using System.Diagnostics;
using System.Reflection;
using MagHag.Subscriptions.Core.Entities;
using MagHag.Subscriptions.Core.Events;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MagHag.Tests.Unit
{
    [TestFixture]
    public class SubscriberTests
    {
        [Test]
        public void connect()
        {
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;initial catalog=MagHag.Subscriptions;Integrated Security = SSPI");

            conn.Open();
        }


        [Test]
        public void CanReflectOverMyLifeChoices()
        {
            Type changedBillingAddressType = typeof (ChangedBillingAddressEvent);

            Type subscriberType = typeof (Subscriber);

            MethodInfo[] methods = subscriberType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            MethodInfo foundMethod = null;

            foreach (MethodInfo methodInfo in methods)
            {
                if (methodInfo.Name == "UpdateFrom")
                {
                    ParameterInfo[] paramters = methodInfo.GetParameters();
                    foreach (ParameterInfo parameter in paramters)
                    {
                        //if (parameter.ParameterType.IsAssignableFrom(changedBillingAddressType))
                        if (parameter.ParameterType ==changedBillingAddressType)
                        {
                            foundMethod = methodInfo;
                            break;
                        }
                    }
                }
            }

            if (foundMethod != null)
            {
                Subscriber sub =new Subscriber();
                foundMethod.Invoke(sub, new[] {new ChangedBillingAddressEvent {Street = "deanbug"}});
            }

                //.SingleOrDefault(methodInfo => methodInfo.Name == "UpdateFrom" &&
                //    methodInfo.GetParameters().Single().GetType().IsAssignableFrom(changedBillingAddressType));
        }

    }
}
