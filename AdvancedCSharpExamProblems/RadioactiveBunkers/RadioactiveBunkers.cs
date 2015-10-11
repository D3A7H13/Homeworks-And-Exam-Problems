using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioactiveBunkers
{
    class RadioactiveBunkers
    {
        static int playerX = 0;
        static int playerY = 0;
        static bool won = false;

        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(' ');

            int numberOfRows = int.Parse(dimensions[0]);
            int numberOfColumns = int.Parse(dimensions[1]);
            int playerRow = 0;
            int playerCol = 0;
            char[,] lair = new char[numberOfRows, numberOfColumns];
            char[,] originalLair = new char[numberOfRows, numberOfColumns];

            for (int row = 0; row < numberOfRows; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int col = 0; col < numberOfColumns; col++)
                {
                    if(line[col] == 'P')
                    {
                        playerCol = col;
                        playerRow = row;
                    }
                    lair[row, col] = line[col];
                    originalLair[row, col] = line[col];
                }

            }

            char[] commands = Console.ReadLine().ToCharArray();
            int nextCol = 0;
            int nextRow = 0;

            foreach (var command in commands)
            {
                bool moreCommands = true;
                if(command == 'R')
                {
                    nextCol = playerCol + 1;
                    nextRow = playerRow;
                    moreCommands = PlayerMove(playerRow, playerCol, lair, originalLair, nextCol, nextRow);
                    playerCol++;
                }
                else if (command == 'U')
                {
                    nextCol = playerCol;
                    nextRow = playerRow - 1;
                    moreCommands = PlayerMove(playerRow, playerCol, lair, originalLair, nextCol, nextRow);
                    playerRow--;
                }
                else if (command == 'L')
                {
                    nextCol = playerCol - 1;
                    nextRow = playerRow;
                    moreCommands = PlayerMove(playerRow, playerCol, lair, originalLair, nextCol, nextRow);
                    playerCol--;
                }
                else if (command == 'D')
                {
                    nextCol = playerCol;
                    nextRow = playerRow + 1;
                    moreCommands = PlayerMove(playerRow, playerCol, lair, originalLair, nextCol, nextRow);
                    playerRow++;
                    
                }
                if(!moreCommands)
                {
                    break;
                }
            }

            PrintLair(numberOfRows, numberOfColumns, lair);
            if(won)
            {
                Console.WriteLine("won: {0} {1}", playerX, playerY);
            }
            else
            {
                Console.WriteLine("dead: {0} {1}", playerX, playerY);
            }
            
        }

        private static bool PlayerMove(int playerRow, int playerCol, char[,] lair, char[,] originalLair, int nextCol, int nextRow)
        {
            bool playerHit = true;
            if (nextRow < 0 || nextRow >= lair.GetLength(0) || nextCol < 0 || nextCol >= lair.GetLength(1))
            {
                playerX = playerRow;
                playerY = playerCol;
                won = true;
                lair[playerRow, playerCol] = '.';
                playerHit = BunniesTurn(playerRow, playerCol, lair, originalLair, nextCol, nextRow);
                return false;
            }
            if(lair[nextRow, nextCol] == 'B')
            {
                playerX = nextRow;
                playerY = nextCol;
                lair[playerRow, playerCol] = '.';
                playerHit = BunniesTurn(playerRow, playerCol, lair, originalLair, nextCol, nextRow);
                return false;
            }
            else if (lair[nextRow, nextCol] == '.')
            {
                lair[nextRow, nextCol] = 'P';
                lair[playerRow, playerCol] = '.';
            }
            playerHit = BunniesTurn(playerRow, playerCol, lair, originalLair, nextCol, nextRow);
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    originalLair[row, col] = lair[row, col];
                }
            }
            if(playerHit)
            {
                playerX = playerRow;
                playerY = playerCol;
            }
            return !playerHit;
        }

        private static bool BunniesTurn(int playerRow, int playerCol, char[,] lair, char[,] originalLair, int nextCol, int nextRow)
        {
            bool playerFound = false;

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if(originalLair[row, col] == 'B')
                    {
                        bool findPlayer = CreateBunnies(lair, row, col);
                        if(findPlayer)
                        {
                            playerX = row;
                            playerY = col - 1 ;
                            playerFound = true;
                        }
                    }
                }
            }
            return playerFound;
        }

        private static bool CreateBunnies(char[,] lair, int row, int col)
        {
            bool hit = false;
            int rowUp = (int)Math.Max(0, row - 1);
            int rowDown = (int)Math.Min(lair.GetLength(0) - 1, row + 1);
            int colLeft = (int)Math.Max(0, col - 1);
            int colRight = (int)Math.Min(lair.GetLength(1) - 1, col + 1);

            if(lair[rowUp, col] == 'P')
            {
                hit = true;
            }
            else if (lair[rowDown, col] == 'P')
            {
                hit = true;
            }
            else if (lair[row, colLeft] == 'P')
            {
                hit = true;
            }
            else if (lair[row, colRight] == 'P')
            {
                hit = true;
            }
            lair[rowUp, col] = 'B';
            lair[rowDown, col] = 'B';
            lair[row, colLeft] = 'B';
            lair[row, colRight] = 'B';
            return hit;
        }

        private static void PrintLair(int numberOfRows, int numberOfColumns, char[,] lair)
        {
            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < numberOfColumns; col++)
                {
                    Console.Write(lair[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}
