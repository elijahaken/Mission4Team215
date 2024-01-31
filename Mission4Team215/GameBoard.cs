public class GameBoard
{
    public static void PrintBoard(char[,] board)
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

    public static char CheckWinner(char[,] board)
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
}
