using System;

namespace SudokuTest
{
        class Program
        {
            const int N = 9;

            static void Main()
            {
                /*int[,] board = new int[N, N];*/

                int[,] board = new int[,]
                                {
                            { 9, 1, 8, 5, 7, 2, 6, 4, 3 },
                            { 7, 5, 3, 6, 9, 4, 1, 8, 2 },
                            { 2, 6, 4, 1, 8, 3, 7, 9, 5 },
                            { 1, 9, 6, 4, 2, 8, 5, 3, 7 },
                            { 3, 8, 2, 7, 5, 6, 9, 1, 4 },
                            { 5, 4, 7, 9, 3, 1, 8, 2, 6 },
                            { 4, 7, 9, 2, 1, 5, 3, 6, 8 },
                            { 8, 2, 5, 3, 6, 9, 4, 7, 1 },
                            { 6, 3, 1, 8, 4, 7, 2, 5, 9 }
                                };

            if (!ReadAndValidateInputData(board))
            {
                Console.WriteLine("Please enter a 9x9 sudoku board: numbers between 1-9 separated by spaces");
            }
            else
            {
                Console.WriteLine(CheckBoard(board));
            }
  
        }

        static bool ReadAndValidateInputData(int[,] board)
        {
            for (int i = 0; i < N; i++)
            {
                string[] line = Console.ReadLine().Split(' ');

                if (line.Length != N)
                {
                    return false;
                }

                for (int j = 0; j < N; j++)
                {
                    if (!int.TryParse(line[j], out board[i, j]))
                    {
                        return false;
                    }

                    if (Convert.ToInt32(line[j]) < 1 || Convert.ToInt32(line[j]) > N)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static bool CheckRow(int[,] board, int row, int col)
        {
            for (int anotherRow = row + 1; anotherRow < N; anotherRow++)
            {
                if (board[row, col] == board[anotherRow, col])
                {
                    return false;
                }
            }

            return true;
        }

        static bool CheckColumn(int[,] board, int row, int col)
        {
            for (int anotherCol = col + 1; anotherCol < N; anotherCol++)
            {
                if (board[row, col] == board[row, anotherCol])
                {
                    return false;
                }
            }

            return true;
        }

        static bool CheckBlock(int[,] board, int row, int col)
        {
            int sqrt = (int)Math.Sqrt(N);

            for (int i = row; i < row + sqrt; i++)
            {
                for (int j = col; j < col + sqrt; j++)
                {
                    if (!CheckRow(board, i, j) || !CheckColumn(board, i, j))
/*                    if (!CheckRow(board, row, col) || !CheckColumn(board, row, col))*/
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static bool CheckBoard(int[,] board)
        {
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    if (!CheckRow(board, row, col) || !CheckColumn(board, row, col))
                    {
                        return false;
                    }
                }
            }


            int sqrt = (int)Math.Sqrt(N);

            for (int row = 0; row < N; row += sqrt)
            {
                for (int col = 0; col < N; col += sqrt)
                {
                    if (!CheckBlock(board, row, col))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}


