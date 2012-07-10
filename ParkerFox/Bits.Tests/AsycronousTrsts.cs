using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitsNPerices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bits.Tests
{
    [TestClass]
    class AsycronousTrsts
    {
        [TestMethod]
        public void CanCallMethod()
        {
            Asyncronous ascyrony = new Asyncronous();
            
            ascyrony.Run();
        }
    }
}
