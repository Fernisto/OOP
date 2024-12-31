namespace CourseWork;

public abstract class BasicGame : IGame
{
    protected static int GameCount = 0;
    public int GameId { get; }
    public string PlayerName { get; }
    public string OpponentName { get; }
    public string GameResult { get; protected set; } // Win\Lose
    public int Rating { get; }
    protected GameEngine Engine { get; } = new GameEngine();

    public BasicGame(string playerName, string opponentName, int rating)
    {
        if (rating < 0)
        {
            throw new ArgumentException("Rating must be a non-negative number.");
        }

        PlayerName = playerName;
        OpponentName = opponentName;
        Rating = rating;
        GameId = ++GameCount;
        GameResult = "Pending";
    }

    public abstract void Play();
    protected void ExecuteGameLoop()
    {
        while (true)
        {
            Engine.DisplayBoard();
            Console.WriteLine($"Player {Engine.GetCurrentTurn()} turn");

            Console.WriteLine("Enter your move (row column): ");
            string input = Console.ReadLine();
            var inputs = input.Split();

            if (inputs.Length != 2 ||
                !int.TryParse(inputs[0], out int x) ||
                !int.TryParse(inputs[1], out int y) ||
                x < 1 || x > 3 || y < 1 || y > 3 ||
                !Engine.MakeMove(x- 1, y - 1))
            {
                Console.WriteLine("Invalid move, try again!");
                continue;
            }

            if (Engine.CheckWinner())
            {
                GameResult = $"{(Engine.GetCurrentTurn() == 'X' ? PlayerName : OpponentName)} wins!";
                Engine.DisplayBoard();
                Console.WriteLine(GameResult);
                break;
            }

            if (Engine.IsDraw())
            {
                GameResult = "Draw";
                Engine.DisplayBoard();
                Console.WriteLine(GameResult);
                break;
            }

            Engine.SwitchTurn();
        }
    }
}