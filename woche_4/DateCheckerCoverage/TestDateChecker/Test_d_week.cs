using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using KalendarRoutines;

namespace TestDateChecker
{
    [TestFixture]
    public class Test_d_week
    {
        [Test]
        public void test_d_week()
        {
            Assert.AreEqual(0, Calendar.d_week(28,1,2018));
        }


    }
}
