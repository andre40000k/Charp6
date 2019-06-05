using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charp6
{
    public class Matrix
    {
        double[,] matrix;

        public int Row { get; protected set; }
        public int Column { get; protected set; }

        public Matrix(int row, int column)
        {
            Row = row;
            Column = column;
            matrix = new double[row, column];
        }

        public Matrix Multiple(Matrix value)
        {
            Matrix result = new Matrix(Row, value.Column);
            Parallel.For(0, Row, i =>
            {
                for (int j = 0; j < value.Column; j++)
                    for (int k = 0; k < value.Row; k++)
                        result.matrix[i, j] += matrix[i, k] * value.matrix[k, j];
            });
            return result;
        }

        public void Read()
        {
            Random rnd = new Random();
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Column; j++)
                {
                    Console.Write("Введите элемент [{0},{1}]: ", i + 1, j + 1);
                    matrix[i, j] = rnd.Next();
                }
        }

        public void Print()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                    Console.Write("{0:f2} ", matrix[i, j]);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов");
            string a = Console.ReadLine();
            int n = Convert.ToInt32(a);
            Matrix vector = new Matrix(1, n);
            Matrix matrix = new Matrix(n, n);
            Console.Clear();
            Console.WriteLine("Ввод вектора");
            vector.Read();
            Console.WriteLine("\nВвод матрицы");
            matrix.Read();
            Console.Clear();
            Matrix result = vector.Multiple(matrix);
            Console.WriteLine("Вектор");
            vector.Print();
            Console.WriteLine("\nМатрица");
            matrix.Print();
            Console.WriteLine("\nРезультат умножения матрицы на вектор");
            result.Print();
            Console.WriteLine("\nНажмите любую клавишу для выхода из программы");
            Console.ReadKey(true);
        }
    }
}