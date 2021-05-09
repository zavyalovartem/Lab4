using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    [TestFixture]
    class RedhefferTests
    {
        [Test]
        public void TestCreation()
        {
            var matrixRedheffer = Program.GenerateRedhefferMatrix(2);
            Assert.AreEqual(matrixRedheffer.data, new double[,] { { 1, 1 }, { 1, 1 } });
        }

        [TestCase(2, 0)]
        [TestCase(4, -1)]
        [TestCase(5, -2)]
        [TestCase(6, -1)]
        public void TestDeterminant(int n, int det)
        {
            var redheffer = Program.GenerateRedhefferMatrix(n);
            var res = Program.DetRec(redheffer);
            Assert.AreEqual(det, res);
        }
    }
}
