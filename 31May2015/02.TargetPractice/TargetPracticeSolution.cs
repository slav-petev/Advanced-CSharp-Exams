using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace _02.TargetPractice
{
    public class TargetPracticeSolution
    {
        public static void Main()
        {
            var staircaseMatrix = CreateStaircaseMatrix();
            var snake = Console.ReadLine();
            InitializeStaircaseMatrix(staircaseMatrix, snake);
            var shotInfo = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            var impactedRow = shotInfo[0];
            var impactedColumn = shotInfo[1];
            var impactRadius = shotInfo[2];

            ClearImpactedCells(staircaseMatrix, impactedRow, impactedColumn,
                impactRadius);
            while (CanShiftCells(staircaseMatrix))
            {
                ShiftCells(staircaseMatrix);
            }

            PrintStaircase(staircaseMatrix);
        }

        private static char[,] CreateStaircaseMatrix()
        {
            var matrixDimensions = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            return new char[matrixDimensions[0], matrixDimensions[1]];
        }

        private static void InitializeStaircaseMatrix(char[,] staircaseMatrix,
            string snake)
        {
            var rows = staircaseMatrix.GetLength(0);
            var columns = staircaseMatrix.GetLength(1);

            var currentSnakePosition = 0;
            for (var i = rows - 1; i >= 0; --i)
            {
                if (i % 2 == 0)
                {
                    for (var j = columns - 1; j >= 0; --j)
                    {
                        SetCurrentSnakePosition(snake, ref currentSnakePosition);
                        staircaseMatrix[i, j] = snake[currentSnakePosition];
                        ++currentSnakePosition;
                    }
                }
                else
                {
                    for (var j = 0; j < columns; ++j)
                    {
                        SetCurrentSnakePosition(snake, ref currentSnakePosition);
                        staircaseMatrix[i, j] = snake[currentSnakePosition];
                        ++currentSnakePosition;
                    }
                }
            }
        }

        private static void SetCurrentSnakePosition(string snake, ref int position)
        {
            if (position == snake.Length)
            {
                position = 0;
            }
        }

        private static void ClearImpactedCells(char[,] staircase,
            int impactedRow, int impactedColumn, int impactRadius)
        {
            var rows = staircase.GetLength(0);
            var columns = staircase.GetLength(1);

            for (var i = 0; i < rows; ++i)
            {
                for (var j = 0; j < columns; ++j)
                {
                    if (IsCellImpacted(i, j, impactedRow, impactedColumn, impactRadius))
                    {
                        staircase[i, j] = ' ';
                    }
                }
            }
        }

        private static bool IsCellImpacted(int row, int column,
            int impactedRow, int imapctedColumn, int impactRadius)
        {
            var result = Math.Pow(impactedRow - row, 2) +
                Math.Pow(imapctedColumn - column, 2);

            return result <= impactRadius * impactRadius;
        }

        private static bool CanShiftCells(char[,] staircase)
        {
            var rows = staircase.GetLength(0);
            var columns = staircase.GetLength(1);

            for (var i = 0; i < rows - 1; ++i)
            {
                for (var j = 0; j < columns; ++j)
                {
                    if (staircase[i, j] != ' ' && staircase[i + 1, j] == ' ')
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void ShiftCells(char[,] staircase)
        {
            var rows = staircase.GetLength(0);
            var columns = staircase.GetLength(1);

            for (var i = 0; i < rows - 1; ++i)
            {
                for (var j = 0; j < columns; ++j)
                {
                    if (staircase[i, j] != ' ' && staircase[i + 1, j] == ' ')
                    {
                        Swap(ref staircase[i, j], ref staircase[i + 1, j]);
                    }
                }
            }
        }

        private static void PrintStaircase(char[,] staircase)
        {
            var staircaseRows = staircase.GetLength(0);
            var staircaseColumns = staircase.GetLength(1);

            for (var i = 0; i < staircaseRows; ++i)
            {
                for (var j = 0; j < staircaseColumns; ++j)
                {
                    Console.Write(staircase[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void Swap(ref char first, ref char second)
        {
            var temp = first;
            first = second;
            second = temp;
        }
    }
}
