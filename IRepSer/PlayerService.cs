namespace CourseWork;

public class PlayerService : IPlayerService
{
    public IPlayerRepository Repository { get; set; }
    private readonly DbContext _context;

    public PlayerService(IPlayerRepository repository, DbContext context)
    {
        this.Repository = repository;
        _context = context;
    }

    public User? GetPlayer(string name)
    {
        return Repository.GetPlayer(name);
    }

    public void AddPlayer(User player)
    {
        if (Repository.GetPlayer(player.username) != null)
        {
            throw new Exception($"Player {player.username} already exists");
        }
        Repository.AddPlayer(player);
    }

    public void GetStats(string username)
    {
        var player = _context.Players.FirstOrDefault(p => p.username == username);
        if (player == null)
        {
            Console.WriteLine("Player not found.");
            return;
        }

        var games = _context.Games.Where(g => g.PlayerName == username || g.OpponentName == username).ToList();

        int totalGames = games.Count;
        
        int ranking = player.rating;

        Console.WriteLine($"Stats for {username}:");
        Console.WriteLine($"- Total Games: {totalGames}");
        Console.WriteLine("- Game Results:");
        foreach (var game in games)
        {
            Console.WriteLine($"  - {game.GameResult}");
        }

        Console.WriteLine($"- Rating: {ranking}");
    }



    public bool RegisterPlayer(User player)
    {
        if (Repository.GetPlayer(player.username) != null)
        {
            Console.WriteLine("Username already taken.");
            return false;
        }

        AddPlayer(player);
        Console.WriteLine("Registration successful!");
        return true;
    }

    public bool Login(string username, string password)
    {
        var player = Repository.GetPlayer(username);
        if (player != null && player.CheckPassword(password))
        {
            Console.WriteLine("Login successful!");
            return true;
        }

        Console.WriteLine("Invalid username or password.");
        return false;
    }


}