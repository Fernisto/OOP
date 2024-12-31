namespace CourseWork;

public class GameHistory:ICommand
{
    private readonly IPlayerService _userService;
    private readonly DbContext _context;

    public GameHistory(IPlayerService userService, DbContext context)
    {
        _userService = userService;
        _context = context;
    }
    public void Execute()
    {
        Console.WriteLine("Game History for Current Player");
        foreach (var games in _context.CurrentUser.GameHistory)
        {
            Console.WriteLine($"Game ID: {games.GameId} | {games.PlayerName} against {games.OpponentName} for {games.Rating} points. Result : {games.GameResult}");
        }
    }

    public string GetInfo()
    {
        return "Game History for Current Player";
    }
}