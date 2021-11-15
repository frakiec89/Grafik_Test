using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grafik_Test.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafik_Test.BL.Tests
{
    [TestClass()]
    public class GraficTests
    {
        [TestMethod()]
        public void GetXforWPFTest_50()
        {
            double w = 100;
            double x = 0;
            double expected = 50;
            double actual = new Grafic(w, w).GetXforWPF(x);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetXforWPFTest_60()
        {
            double w = 120;
            double x = 0;
            double expected = 60;
            double actual = new Grafic(w, w).GetXforWPF(x);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetXforWPFTest_100_10_60()
        {
            double w = 100;
            double x = 10;
            double expected = 60;
            double actual = new Grafic(w, w).GetXforWPF(x);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void GetXforWPFTest_100_10_Min60()
        {
            double w = 100;
            double x = -10;
            double expected = 40;
            double actual = new Grafic(w, w).GetXforWPF(x);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetXforMathTest_100_40_min10()
        {
            double w = 100;
            double x = 40;
            double expected = -10;
            double actual = new Grafic(w, w).GetXforMath(x);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetXforMathTest_100_60_10()
        {
            double w = 100;
            double x = 60;
            double expected = 10;
            double actual = new Grafic(w, w).GetXforMath(x);
            Assert.AreEqual(expected, actual);
        }
    }
}