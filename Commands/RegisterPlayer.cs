namespace CourseWork;

public class RegisterPlayer : ICommand
{
    private readonly IPlayerService _userService;
    private readonly DbContext _context;
    public RegisterPlayer(IPlayerService userService, DbContext context)
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
                _userService.RegisterPlayer(new User(username, password, 100));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            } 
        }
        else
        {
            Console.WriteLine("You have already logged in!");
        }
    }

    public string GetInfo()
    {
        return "Register a new player.";
    }
}
