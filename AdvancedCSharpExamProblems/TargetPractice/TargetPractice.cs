//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TargetPractice
//{
//    class TargetPractice
//    {
//        static void Main(string[] args)
//        {
//            string[] dimensions = Console.ReadLine().Split();
//            string snake = Console.ReadLine();
//            string[] shotInfo = Console.ReadLine().Split();

//            int rows = int.Parse(dimensions[0]);
//            int cols = int.Parse(dimensions[1]);
//            char[,] matrix = new char[rows, cols];

//            FillMatrix(snake, matrix);

//            HitMatrix(matrix, shotInfo, rows, cols, 'U');
//            for (int i = 0; i < matrix.GetLength(0); i++)
//            {
//                for (int k = 0; k < matrix.GetLength(1); k++)
//                {
//                    Console.Write("{0} ", matrix[i, k]);
//                }
//                Console.WriteLine();
//            }

//        }

//        private static void FillMatrix(string snake, char[,] matrix)
//        {
//            int filler = 0;
//            char d = 'l';

//            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
//            {
//                if (d == 'l')
//                {
//                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
//                    {
//                        if (filler == snake.Length)
//                        {
//                            filler = 0;
//                        }
//                        matrix[i, j] = snake[filler];
//                        filler++;
//                    }
//                    d = 'r';
//                }
//                else
//                {
//                    for (int j = 0; j < matrix.GetLength(1); j++)
//                    {
//                        if (filler == snake.Length)
//                        {
//                            filler = 0;
//                        }
//                        matrix[i, j] = snake[filler];
//                        filler++;
//                    }
//                    d = 'l';
//                }

//            }
//        }

//        private static void HitMatrix(char[,] matrix, string[] shotInfo, int rows, int cols, char d)
//        {
//            int rowImpact = int.Parse(shotInfo[0]);
//            int colImpact = int.Parse(shotInfo[1]);
//            int radius = int.Parse(shotInfo[2]);
//            int colFrom = (int)Math.Max(0, colImpact - radius);
//            int colTo = (int)Math.Min(matrix.GetLength(1) - 1, colImpact + radius);
//            int rowFrom = (int)Math.Max(0, rowImpact - radius);
//            int rowTo = (int)Math.Min(matrix.GetLength(0) - 1, rowImpact + radius);

//            matrix[rowImpact, colImpact] = ' ';

//            for (int i = colFrom; i <= colTo; i++)
//            {
//                matrix[rowImpact, i] = ' ';
//            }
//            for (int i = rowFrom; i <= rowTo; i++)
//            {
//                matrix[i, colImpact] = ' ';
//            }
//        }
//    }
//}
using System;

public class TargetPractice
{
    public static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(' ');

        int numberOfRows = int.Parse(dimensions[0]);
        int numberOfColumns = int.Parse(dimensions[1]);

        char[,] matrix = new char[numberOfRows, numberOfColumns];

        string snake = Console.ReadLine();

        FillMatrix(numberOfRows, numberOfColumns, snake, matrix);

        string[] shotArguments = Console.ReadLine().Split(' ');
        int impactRow = int.Parse(shotArguments[0]);
        int impactCol = int.Parse(shotArguments[1]);
        int radius = int.Parse(shotArguments[2]);

        FireAShot(matrix, impactRow, impactCol, radius);

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            RunGravity(matrix, col);
        }

        PrintMatrix(matrix);
    }

    static void RunGravity(char[,] matrix, int col)
    {
        while (true)
        {
            bool hasFallen = false;

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                char topChar = matrix[row - 1, col];
                char currentChar = matrix[row, col];
                if (currentChar == ' ' && topChar != ' ')
                {
                    matrix[row, col] = topChar;
                    matrix[row - 1, col] = ' ';
                    hasFallen = true;
                }
            }

            if (!hasFallen)
            {
                break;
            }
        }
    }

    private static void FireAShot(char[,] matrix, int impactRow, int impactCol, int radius)
    {
        //(x - center_x)^2 + (y - center_y)^2 <= radius^2.
        for (int row = 0; row < matrix.GetLongLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLongLength(1); col++)
            {
                if ((col - impactCol) * (col - impactCol) + (row - impactRow) * (row - impactRow) <= radius * radius)
                {
                    matrix[row, col] = ' ';
                }
            }
        }
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLongLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLongLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }

            Console.WriteLine();
        }
    }

    private static void FillMatrix(int numberOfRows, int numberOfColumns, string snake, char[,] matrix)
    {
        bool isMovingLeft = true;
        int currentIndex = 0;

        for (int row = numberOfRows - 1; row >= 0; row--)
        {
            if (isMovingLeft)
            {
                for (int col = numberOfColumns - 1; col >= 0; col--)
                {
                    if (currentIndex >= snake.Length)
                    {
                        currentIndex = 0;
                    }

                    matrix[row, col] = snake[currentIndex];
                    currentIndex++;
                }
            }
            else
            {
                for (int col = 0; col < numberOfColumns; col++)
                {
                    if (currentIndex >= snake.Length)
                    {
                        currentIndex = 0;
                    }

                    matrix[row, col] = snake[currentIndex];
                    currentIndex++;
                }
            }

            isMovingLeft = !isMovingLeft;
        }
    }
}