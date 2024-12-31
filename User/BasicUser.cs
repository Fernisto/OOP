namespace CourseWork;

public class User
{
    public string username { get; set; }
    protected string password { get; set; }
    public int rating { get; set; }
    public List<BasicGame> GameHistory { get; } = new List<BasicGame>();

    public User(string username, string password, int rating)
    {
        this.username = username;
        this.password = password;
        this.rating = rating;
    }

    public bool CheckPassword(string inputPassword)
    {
        return password == inputPassword;
    }

    public void AddGameToHistory(BasicGame game)
    {
        GameHistory.Add(game);
    }

    public void DisplayGameHistory()
    {
        Console.WriteLine($"Game history for {username}:");
        foreach (var game in GameHistory)
        {
            Console.WriteLine($"Game {game.GameId}: {game.PlayerName} vs {game.OpponentName} for {game.Rating} points - Result: {game.GameResult}");
        }
    }
}