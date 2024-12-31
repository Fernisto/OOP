namespace CourseWork;

public class LoginPlayer : ICommand
{
    private readonly IPlayerService _userService;
    private readonly DbContext _context;

    public LoginPlayer(IPlayerService userService, DbContext context)
    {
        _userService = userService;
        _context = context;
    }

    public void Execute()
    {
        if (_context.CurrentUser == null)
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            try
            {
                if (_userService.Login(username, password))
                {
                    
                    var player = _userService.GetPlayer(username);
                    _context.CurrentUser = player;
                    Console.WriteLine($"Welcome, {player.username}!");
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during login: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("You have already logged in!");
        }
        
    }

    public string GetInfo()
    {
        return "Log in as an existing player.";
    }
}