using System;
using Minutes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddMinutesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MinutesTest1()
        {
            AMorPM one = new AMorPM();
            string result = one.AddMinutes("11:59:00 AM", 1);

            Assert.AreEqual(result, "12:00:00 PM");
        }

        [TestMethod]
        public void MinutesTest2()
        {
            AMorPM one = new AMorPM();
            string result = one.AddMinutes("12:00:00 AM", 1440);
            Assert.AreEqual(result, "12:00:00 AM");
        }

        [TestMethod]
        public void MinutesTest3()
        {
            AMorPM one = new AMorPM();
            string result = one.AddMinutes("11:00:00 AM", 120);

            Assert.AreEqual(result, "1:00:00 PM");
        }

        [TestMethod]
        public void MinutesTest4()
        {
            AMorPM one = new AMorPM();
            string result = one.AddMinutes("1:00:00 AM", 120);

            Assert.AreEqual(result, "3:00:00 AM");
        }
        [TestMethod]
        public void MinutesTest5()
        {
            AMorPM one = new AMorPM();
            string result = one.AddMinutes("SDFJKLSDF$#@", 120);

            Assert.AreEqual(result, "");
        }

        [TestMethod]
        public void MinutesTest6()
        {
            AMorPM one = new AMorPM();
            string result = one.AddMinutes("4:00:00 AM", -120);

            Assert.AreEqual(result, "2:00:00 AM");
        }
    }
}
