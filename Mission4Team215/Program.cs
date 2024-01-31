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
        int row, col;
        char playerSymbol = isPlayer1Turn ? 'X' : 'O';

        do
        {
            Console.WriteLine($"Player {(isPlayer1Turn ? "1" : "2")}'s turn. Enter row (1-3):");
            row = (Convert.ToInt32(Console.ReadLine())) - 1;
            Console.WriteLine($"Player {(isPlayer1Turn ? "1" : "2")}'s turn. Enter column (1-3):");
            col = (Convert.ToInt32(Console.ReadLine())) - 1;
        } while (row < 0 || row > 2 || col < 0 || col > 2 || board[row, col] != ' ');

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
