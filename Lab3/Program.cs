using System;
using System.Text;

namespace Lab3
{
    class Program
    {
        public static int amountOfOperations;

        public static void Main()
        {
            Console.WriteLine("Введите размер матрицы Редхеффера");
            var redhefferN = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите размеры левой матрицы через запятую");
            var nLeft = Console.ReadLine().Split(',');
            var nLeftInt = int.Parse(nLeft[0]);
            var mLeftInt = int.Parse(nLeft[1]);
            Console.WriteLine("Введите размер правой матрицы");
            var mRight = int.Parse(Console.ReadLine());
            double[,] left = new double[nLeftInt, mLeftInt];
            double[,] right = new double[1, mRight];
            for (var i = 0; i < mLeftInt; i++)
            {
                Console.WriteLine("Введите коэффициенты текущей строки левой матрицы через запятую");
                var leftStr = Console.ReadLine().Split(',');
                for (var j = 0; j < nLeftInt; j++)
                {
                    left[i, j] = int.Parse(leftStr[j]);
                }
            }
            Console.WriteLine("Введите коэффициенты правой матрицы через запятую");
            var rightStr = Console.ReadLine().Split(',');
            for (var i = 0; i < mRight; i++)
            {
                right[0, i] = int.Parse(rightStr[i]);
            }
            var leftMatrix = new Matrix(left);
            var rightMatrix = new Matrix(right);
            var kramer = Kramer(leftMatrix, rightMatrix);
            Matrix redheffer = GenerateRedhefferMatrix(redhefferN);
            Matrix matrix = redheffer; 
            var det = DetRec(matrix);
            var sb = new StringBuilder();
            foreach (var coeff in kramer.data)
            {
                sb.Append(coeff + " ");
            }
            Console.WriteLine("Определитель матрицы Редхеффера заданного размера равен: " + det);
            Console.WriteLine("Решение системы методом Крамера: " + sb.ToString());
        }

        public static double DetRec(Matrix matrix)
        {
            if (matrix.Length == 4)
            {
                amountOfOperations += 2;
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            double sign = 1, result = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                Matrix minor = Matrix.GetMinor(matrix, i);
                result += sign * matrix[0, i] * DetRec(minor);
                amountOfOperations += 2;
                sign = -sign;
            }
            return result;
        }

        public static Matrix GenerateRedhefferMatrix(int n)
        {
            Matrix result = new Matrix(n, n);
            for (var i = 1; i <= n; i++)
            {
                for (var j = 1; j <= n; j++)
                {
                    if (j % i == 0 || j == 1)
                    {
                        result[i - 1, j - 1] = 1;
                    }
                    else
                    {
                        result[i - 1, j - 1] = 0;
                    }
                }
            }
            return result;
        }

        public static Matrix Kramer(Matrix left, Matrix right)
        {
            var res = new Matrix(1, left.N);
            // проверка, является ли матрица квадратной
            if (left.M != left.N)
                throw new Exception("Матрица не является квадратной");
            double det = DetRec(left); // вычисление определителя
                                          // матрицы коэффициентов
                                          // проверка определенности системы
            if (det == 0)
                return null;

            var rang = left.M;
            // вычисление корней по формулам Крамера
            Matrix temp = left.Copy();
            for (int j = 0; j < left.N; j++)
            {
                for (int i = 0; i < left.N; i++)
                    temp[i, j] = right[0, i];
                res[0, j] = DetRec(temp) / det;
                for (int i = 0; i < left.N; i++)
                temp[i, j] = left[i, j];
            }
            return res;
        }
    }
}
