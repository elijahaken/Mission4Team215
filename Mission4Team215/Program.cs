// Team 2-15

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Tic-Tac-Toe!");

        char[,] board = new char[3, 3];
        InitializeBoard(board);

        bool isPlayer1Turn = true;
        bool gameEnded = false;
        char winner = ' ';

        while (!gameEnded)
        {
            PrintBoard(board);
            TakeTurn(isPlayer1Turn, board);
            winner = CheckWinner(board);
            gameEnded = winner != ' ' || IsBoardFull(board);
            isPlayer1Turn = !isPlayer1Turn;
        }

        PrintBoard(board);
        if (winner == ' ')
        {
            Console.WriteLine("The game is a draw!");
        }
        else
        {
            Console.WriteLine($"Player {(winner == 'X' ? "1" : "2")} wins!");
        }
    }

    static void InitializeBoard(char[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                board[i, j] = ' ';
            }
        }
    }

    static void PrintBoard(char[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write($" {board[i, j]} ");
                if (j < board.GetLength(1) - 1)
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
            if (i < board.GetLength(0) - 1)
            {
                Console.WriteLine("-----------");
            }
        }
    }

    static void TakeTurn(bool isPlayer1Turn, char[,] board)
    {
        string stRow;
        string stCol;
        int row = 4;
        int col = 4;
        char playerSymbol = isPlayer1Turn ? 'X' : 'O';
        bool validRow = false;
        bool validCol = false;
        bool validGuess = false;

        do
        {
            do
            {
                Console.WriteLine($"Player {(isPlayer1Turn ? "1" : "2")}'s turn. Enter row (1-3):");
                stRow = Console.ReadLine();
                if (int.TryParse(stRow, out int parsedRow) && parsedRow > 0)
                {
                    row = (Convert.ToInt32(stRow)) - 1;
                    if (row < 0 || row > 2)
                    {
                        Console.WriteLine("Please enter an integer between 1 and 3");
                    }
                    else
                    {
                        validRow = true;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter an integer between 1 and 3");
                }
            } while (!validRow);

            do
            {
                Console.WriteLine("Enter column (1-3):");
                stCol = Console.ReadLine();
                if (int.TryParse(stCol, out int parsedRow) && parsedRow > 0)
                {
                    col = (Convert.ToInt32(stCol)) - 1;
                    if (col < 0 || col > 2)
                    {
                        Console.WriteLine("Please enter an integer between 1 and 3");
                    }
                    else
                    {
                        validCol = true;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter an integer number");
                }
            } while (!validCol);

            if (board[row, col] != ' ')
            {
                Console.WriteLine("This space is taken!");
            }
            else
            {
                validGuess = true;
            }

        } while (!validGuess);

        board[row, col] = playerSymbol;
    }

    static char CheckWinner(char[,] board)
    {
        // Check rows, columns and diagonals for a winner
        for (int i = 0; i < 3; i++)
        {
            // Check rows
            if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != ' ')
                return board[i, 0];

            // Check columns
            if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != ' ')
                return board[0, i];
        }

        // Check diagonals
        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != ' ')
            return board[0, 0];
        if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != ' ')
            return board[0, 2];

        return ' '; // No winner yet
    }

    static bool IsBoardFull(char[,] board)
    {
        foreach (var space in board)
        {
            if (space == ' ')
            {
                return false;
            }
        }
        return true;
    }
}
