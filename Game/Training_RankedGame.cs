namespace CourseWork;
public class RankedGame : BasicGame
{
    public RankedGame(string playerName, string opponentName, int rating)
        : base(playerName, opponentName, rating)
    {
    }

    public override void Play()
    {
        Console.WriteLine($"Ranked game started between {PlayerName} and {OpponentName}!");
        ExecuteGameLoop();
    }
}

public class TrainingGame : BasicGame
{
    public TrainingGame(string playerName, string opponentName)
        : base(playerName, opponentName, 0)
    {
    }

    public override void Play()
    {
        Console.WriteLine($"Training game started between {PlayerName} and {OpponentName}!");
        ExecuteGameLoop();
    }
}
