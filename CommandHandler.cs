namespace CourseWork;

public class CommandHandler
{
    private readonly DbContext _context;

    public Dictionary<string, ICommand> Commands { get; }

    public CommandHandler(IPlayerService userService, IGameService gameService, DbContext context)
    {
        _context = context;

        Commands = new Dictionary<string, ICommand>(StringComparer.OrdinalIgnoreCase)
        {
            { "register", new RegisterPlayer(userService,context) },
            { "login", new LoginPlayer(userService, context) },
            { "play game", new CreateGame(gameService, userService, context) },
            { "game history", new GameHistory(userService, context) },
            { "players online", new PlayersOnline(context) },
            { "logout", new UnLo( context) },
            { "exit", new ExitCommand() }
        };
    }

    public void Start()
    {
        while (true)
        {
            
            Console.WriteLine("\nEnter command \"help\" to see a list of commands:");
            var input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input)) continue;

            if (input.Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var command in Commands)
                {
                    Console.WriteLine($"{command.Key} - {command.Value.GetInfo()}");
                }
            }
            else if (Commands.ContainsKey(input))
            {
                try
                {
                    Commands[input].Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error executing command: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Unknown command. Enter \"help\" to see available commands.");
            }
        }
    }
}