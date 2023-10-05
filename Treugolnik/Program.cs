
//int[][] triangle = new int[10][];
//// первая строка
//triangle[0] = new int[] { 1 };

//for (int i = 1; i < triangle.Length; i++)
//{
//    triangle[i] = new int[i + 1];
//    for (int j = 0; j <= i; j++)
//    {
//        if (j == 0 || j == i)
//            triangle[i][j] = 1;
//        else
//        {
//            triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
//        }
//    }
//}

//for (int i = 0; i < triangle.Length; i++)
//{
//    for (int j = 0; j < triangle[i].Length; j++)
//    {
//        Console.Write("{0,-3} ", triangle[i][j]);
//    }
//    Console.WriteLine();
//}

//Console.ReadKey();

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace PascalTriangle
//{

//    class PascalTriangle
//    {
//        static void Main(string[] args)
//        {


//            Console.Write("Сколько строчек: ");
//            string input = Console.ReadLine();

//            int n = Convert.ToInt32(input);

//            for (int y = 0; y < n; y++)
//            {
//                int c = 1;
//                for (int q = 0; q < n - y; q++)
//                {
//                    System.Console.Write("   ");
//                }

//                for (int x = 0; x <= y; x++)
//                {
//                    System.Console.Write("   {0:D} ", c);
//                    c = c * (y - x) / (x + 1);
//                }
//                System.Console.WriteLine();
//                System.Console.WriteLine();
//            }
//            System.Console.WriteLine();
//        }

//    }
//}
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество строк матрицы: ");
        if (!int.TryParse(Console.ReadLine(), out int rows) || rows < 1)
        {
            Console.WriteLine("Неверный формат ввода.");
            return;
        }

        Console.Write("Введите количество столбцов матрицы: ");
        if (!int.TryParse(Console.ReadLine(), out int cols) || cols < 1)
        {
            Console.WriteLine("Неверный формат ввода.");
            return;
        }

        long numberOfPaths = CalculatePaths(rows, cols);

        Console.WriteLine("Количество путей от левого верхнего угла до правого нижнего через треугольник Паскаля: " + numberOfPaths);
    }

    static long CalculatePaths(int rows, int cols)
    {
        if (rows == 0 || cols == 0)
        {
            return 0;
        }

        long[,] array = new long[rows, cols];

        // Инициализируем первую строку и первый столбец единицами
        for (int i = 0; i < rows; i++)
        {
            array[i, 0] = 1;
        }
        for (int j = 0; j < cols; j++)
        {
            array[0, j] = 1;
        }

        // Заполняем остальные элементы матрицы с использованием формулы
        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < cols; j++)
            {
                array[i, j] = array[i - 1, j] + array[i, j - 1];
            }
        }

        return array[rows - 1, cols - 1];
    }
}