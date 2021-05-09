using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    [TestFixture]
    class MatrixTests
    {
        [Test]
        public void TestCreateFromDimensionsSquare()
        {
            var matrix = new Matrix(3, 3);
            Assert.AreEqual(matrix.data, new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } });
        }

        [Test]
        public void TestCreateFromDimensions()
        {
            var matrix = new Matrix(1, 3);
            Assert.AreEqual(matrix.data, new double[,] { { 0, 0, 0 } });
        }

        [Test]
        public void TestCreateFromData()
        {
            var data = new double[,] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            var matrix = new Matrix(data);
            Assert.AreEqual(matrix.data, data);
        }

        [Test]
        public void TestIdentityMatrix()
        {
            var identityMatrix = new Matrix(3, 3);
            var res = identityMatrix.CreateIdentityMatrix(3);
            Assert.AreEqual(res.data, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });
        }

        [Test]
        public void TestMultiplicationOnNumber()
        {
            var matrix = new Matrix(2, 2).CreateIdentityMatrix(2);
            matrix *= 2;
            Assert.AreEqual(matrix.data, new double[,] { { 2, 0 }, { 0, 2 } });
        }

        [Test]
        public void TestMatrixMultiplication()
        {
            var matrix1 = new Matrix(new double[,] { { 2, 0 }, { 0, 2 } });
            var matrix2 = new Matrix(new double[,] { { 2, 0 }, { 0, 2 } });
            var res = matrix1 * matrix2;
            Assert.AreEqual(res.data, new double[,] { { 4, 0 }, { 0, 4 } });
        }

        [Test]
        public void TestMatrixAddition()
        {
            var matrix1 = new Matrix(new double[,] { { 2, 0 }, { 0, 2 } });
            var matrix2 = new Matrix(new double[,] { { 2, 0 }, { 0, 2 } });
            var res = matrix1 + matrix2;
            Assert.AreEqual(res.data, new double[,] { { 4, 0 }, { 0, 4 } });
        }

        [Test]
        public void TestMatrixSubtraction()
        {
            var matrix1 = new Matrix(new double[,] { { 2, 0 }, { 0, 2 } });
            var matrix2 = new Matrix(new double[,] { { 2, 0 }, { 0, 2 } });
            var res = matrix1 - matrix2;
            Assert.AreEqual(res.data, new double[,] { { 0, 0 }, { 0, 0 } });
        }

        [Test]
        public void TestGetLength()
        {
            var matrix = new Matrix(3, 2);
            var dim1 = matrix.GetLength(0);
            var dim2 = matrix.GetLength(1);
            Assert.AreEqual(new int[] { 3, 2 }, new int[] { dim1, dim2 });
        }

        [Test]
        public void TestGetTranspose()
        {
            var matrix = new Matrix(new double[,] { { 2, 0, 3 }, { 0, 2, 1 }, { 1, 2, 3 } });
            var res = matrix.CreateTransposeMatrix();
            var expected = new double[,] { { 2, 0, 1 }, { 0, 2, 2 }, { 3, 1, 3 } };
            Assert.AreEqual(res.data, expected);
        }

        [Test]
        public void TestGetMinor()
        {
            var matrix = new Matrix(new double[,] { { 2, 0, 3 }, { 0, 2, 1 }, { 1, 2, 3 } });
            var res = Matrix.GetMinor(matrix, 0);
            var expected = new double[,] { { 2, 1 }, { 2, 3 } };
            Assert.AreEqual(res.data, expected);
        }
    }
}
