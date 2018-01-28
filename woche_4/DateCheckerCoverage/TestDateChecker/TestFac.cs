using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalendarRoutines;
using NUnit.Framework;

namespace TestDateChecker
{
    [TestFixture]
    class TestFac
    {

        [SetUp]
        public void Init()
        {
            Fac fac = new Fac();

        }

        [Test]
        public void T1()
        {
            //x = 2;
            Assert.AreEqual(2,Fac.factorial(2));



        }


    }
}
