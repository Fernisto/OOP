namespace CourseWork;

public class PlayersOnline:ICommand
{
    private readonly DbContext _context;

    public PlayersOnline(DbContext context)
    {
        _context = context;
    }
    public void Execute()
    {
        Console.WriteLine("Players Online");
        foreach (var player in _context.Players)
        {
            Console.WriteLine($"Player Name: {player.username}");
        }
    }

    public string GetInfo()
    {
        return "Shows Players Online";
    }
}