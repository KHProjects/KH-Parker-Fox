using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ParkerFox.Core;
using ParkerFox.Core.Entities.Magazine;

namespace ParkerFox.UnitTests.Core.Entities.Magazine
{
    [TestFixture]
    public class SubscriptionTests
    {
        [Test]
        public void CanCalculateEndOfSubscriptionForUpFrontTerm()
        {
            SystemTime.Now = () => new DateTime(2012, 12, 21);

            var subscription = new Subscription();

            subscription.Terms = new List<SubscriptionTerm>
                {
                    new SubscriptionTerm
                        {
                            StartDate = new DateTime(2012, 12, 21),
                            Type = SubscriptionTermTypes.UpFront
                        }
                };
        }
    }
}
