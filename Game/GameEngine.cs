namespace CourseWork;

public class GameEngine
{
    private readonly char[,] _board = new char[3, 3];
    private char _currentTurn = 'X';

    public GameEngine()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                _board[i, j] = ' ';
            }
        }
    }

    public void DisplayBoard()
    {
        Console.Clear();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(_board[i, j]);
                if (j < 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("--+---+--");
        }
    }

    public bool MakeMove(int x, int y)
    {
        if (x < 0 || x >= 3 || y < 0 || y >= 3 || _board[x, y] != ' ')
        {
            return false;
        }

        _board[x, y] = _currentTurn;
        return true;
    }

    public bool CheckWinner()
    {
        // Check rows and columns
        for (int i = 0; i < 3; i++)
        {
            if ((_board[i, 0] == _currentTurn && _board[i, 1] == _currentTurn && _board[i, 2] == _currentTurn) ||
                (_board[0, i] == _currentTurn && _board[1, i] == _currentTurn && _board[2, i] == _currentTurn))
            {
                return true;
            }
        }

        // Check diagonals
        if ((_board[0, 0] == _currentTurn && _board[1, 1] == _currentTurn && _board[2, 2] == _currentTurn) ||
            (_board[0, 2] == _currentTurn && _board[1, 1] == _currentTurn && _board[2, 0] == _currentTurn))
        {
            return true;
        }

        return false;
    }

    public bool IsDraw()
    {
        foreach (var cell in _board)
        {
            if (cell == ' ')
            {
                return false;
            }
        }

        return true;
    }

    public void SwitchTurn()
    {
        _currentTurn = (_currentTurn == 'X') ? 'O' : 'X';
    }

    public char GetCurrentTurn()
    {
        return _currentTurn;
    }
    
    public static BasicGame GameBetween(User player1, User player2, int rating)
    {
        return rating > 0
            ? new RankedGame(player1.username, player2.username, rating)
            : new TrainingGame(player1.username, player2.username);
    }

}

