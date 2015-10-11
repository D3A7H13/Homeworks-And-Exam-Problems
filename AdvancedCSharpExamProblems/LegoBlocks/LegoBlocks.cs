using System;
using System.Collections.Generic;
using System.Linq;

namespace LegoBlocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine().Trim());

            int[][] firstJagged = new int[numberOfRows][];
            int[][] secondJagged = new int[numberOfRows][];


            for (int i = 0; i < numberOfRows; i++)
            {
                firstJagged[i] = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            for (int i = 0; i < numberOfRows; i++)
            {
                secondJagged[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            CompareArrays(firstJagged, secondJagged, numberOfRows);

        }

        private static void CompareArrays(int[][] firstJagged, int[][] secondJagged, int numberOfRows)
        {
            int[] cols = new int[numberOfRows];
            for (int i = 0; i < cols.Length; i++)
            {
                cols[i] = firstJagged[i].GetLength(0) + secondJagged[i].GetLength(0);
            }

            bool isMatrix = true; 

            for (int i = 0; i < cols.Length - 1; i++)
            {
                if(cols[i] != cols[i + 1])
                {
                    isMatrix = false;
                    break;
                }
            }

            if(isMatrix)
            {
                DrawMatrix(firstJagged, secondJagged, numberOfRows, cols[0]);
            }
            else
            {
                Console.WriteLine("The total number of cells is: {0}", cols.Sum());
            }
        }

        private static void DrawMatrix(int[][] firstJagged, int[][] secondJagged, int numberOfRows, int numberOfCols)
        {
            int[,] matrix = new int[numberOfRows, numberOfCols];
            for (int i = 0; i < firstJagged.GetLength(0); i++)
            {
                for (int j = 0; j < firstJagged[i].GetLength(0); j++)
                {
                    matrix[i, j] = firstJagged[i][j];
                }
            }

            for (int i = 0; i < secondJagged.GetLength(0); i++)
            {
                int[] sortedArray = secondJagged[i].Reverse().ToArray();
                for (int j = firstJagged[i].GetLength(0); j < firstJagged[i].GetLength(0) + secondJagged[i].GetLength(0); j++)
                {
                    matrix[i, j] = sortedArray[j - firstJagged[i].GetLength(0)];
                }
            }
            PrintMatrix(matrix);

        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row.Add(matrix[i, j]);
                }
                Console.WriteLine("[{0}]", string.Join(", ", row));
            }
        }
    }
}
