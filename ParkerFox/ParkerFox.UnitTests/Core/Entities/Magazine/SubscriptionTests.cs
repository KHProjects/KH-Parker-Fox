using System;
using System.Collections.Generic;
using NUnit.Framework;
using ParkerFox.Core;
using ParkerFox.Core.Entities.Publication;

namespace ParkerFox.UnitTests.Core.Entities.Magazine
{
    [TestFixture]
    public class SubscriptionTests
    {
        [Test]
        public void CanCalculateEndOfSubscriptionForUpFrontTerm()
        {
            SystemTime.Now = () => new DateTime(2012, 12, 21);

            //var subscription = new Subscription();

            //subscription.Terms = new List<SubscriptionTerm>
            //    {
            //        new SubscriptionTerm
            //            {
            //                StartDate = new DateTime(2012, 12, 21),
            //                Type = SubscriptionPaymentTypes.UpFront,
            //                Term = new TimePeriod{Interval = TimePeriodIntervals.Months, Quantity = 1}
            //            }
            //    };

            //Assert.IsTrue(subscription.GetExpirationDate() == DateTime.Parse("21/02/2013"));
        }
    }
}
