namespace CourseWork;

public class CreateGame : ICommand
{
    private readonly IGameService _gameService;
    private readonly IPlayerService _userService;
    private readonly DbContext _context;

    public CreateGame(IGameService gameService, IPlayerService userService, DbContext context)
    {
        _gameService = gameService;
        _userService = userService;
        _context = context;
    }

    public void Execute()
    {
        var currentPlayer = _context.CurrentUser;

        if (currentPlayer == null)
        {
            Console.WriteLine("Player not found.");
            return;
        }

        Console.WriteLine("Enter opponent's username:");
        var opponentUsername = Console.ReadLine();
        var opponent = _userService.GetPlayer(opponentUsername);

        if (opponent == null)
        {
            Console.WriteLine("Opponent not found.");
            return;
        }

        Console.WriteLine("Choose game type:\n1. Ranked Game\n2. Training Game");
        int gameType = int.Parse(Console.ReadLine());

        int rating = 0;
        if (gameType == 1)
        {
            Console.WriteLine("Enter game rating:");
            rating = int.Parse(Console.ReadLine());
        }

        try
        {
            _gameService.CreateGame(gameType, currentPlayer, opponent, rating);
            Console.WriteLine("Game created successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating game: {ex.Message}");
        }
    }

    public string GetInfo()
    {
        return "Start a new game.";
    }
}
