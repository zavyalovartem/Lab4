using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    [TestFixture]
    class KramerTests
    {
        [Test]
        public void testSolving()
        {
            double[,] left =
{
                { 3, -2, 4},
                { 3, 4, -2},
                {2, -1, -1 }
            };
            double[,] right =
            {
                {21, 9, 10}
            };
            var leftMatrix = new Matrix(left);
            var rightMatrix = new Matrix(right);
            var kramer = Program.Kramer(leftMatrix, rightMatrix);
            var expected = new double[,] { { 5, -1, 1 } };
            Assert.AreEqual(expected, kramer.data);
        }
    }
}
