using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMathTests
{
    [TestClass]
    public class BasicMathsTests
    {
        [TestMethod]
        [DataRow(1.0, 1.0, 2.0)] // EP: Positive numbers
        [DataRow(-1.0, -1.0, -2.0)] // EP: Negative numbers
        [DataRow(0.0, 0.0, 0.0)] // EP: Zero
        [DataRow((double)int.MaxValue, 1.0, (double)int.MaxValue + 1.0)] // BVA: Upper boundary
        [DataRow((double)int.MinValue, -1.0, (double)int.MinValue - 1.0)] // BVA: Lower boundary
        public void Test_AddMV(double a, double b, double expected)
        {
            BasicMaths bm = new BasicMaths();
            double actual = bm.Add(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(5.0, 3.0, 2.0)]
        [DataRow(-5.0, -3.0, -2.0)]
        [DataRow(0.0, 0.0, 0.0)]
        [DataRow((double)int.MinValue, 1.0, (double)int.MinValue - 1.0)]
        [DataRow((double)int.MaxValue, -1.0, (double)int.MaxValue + 1.0)]
        public void Test_SubtractMV(double a, double b, double expected)
        {
            BasicMaths bm = new BasicMaths();
            double actual = bm.Subtract(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(4.0, 5.0, 20.0)]
        [DataRow(-4.0, -5.0, 20.0)]
        [DataRow(-4.0, 5.0, -20.0)]
        [DataRow(100.0, 0.0, 0.0)]
        public void Test_MultiplyMV(double a, double b, double expected)
        {
            BasicMaths bm = new BasicMaths();
            double actual = bm.Multiply(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(10.0, 2.0, 5.0)]
        [DataRow(-10.0, -2.0, 5.0)]
        [DataRow(-10.0, 2.0, -5.0)]
        public void Test_DivideMV(double a, double b, double expected)
        {
            BasicMaths bm = new BasicMaths();
            double actual = bm.Divide(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_DivideByZero()
        {
            BasicMaths bm = new BasicMaths();
            try
            {
                bm.Divide(10.0, 0.0);

                Assert.Fail("Expected a DivideByZeroException to be thrown.");
            }
            catch (DivideByZeroException)
            {
            }
        }
    }
}