namespace CourseWork;

public class PlayerService : IPlayerService
{
    public IPlayerRepository Repository { get; set; }

    public PlayerService(IPlayerRepository repository)
    {
        this.Repository = repository;
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