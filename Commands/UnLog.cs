namespace CourseWork;

public class UnLo: ICommand
{
    private readonly DbContext _context;
    public UnLo( DbContext context)
    {
        _context = context;
    }
    public void Execute()
    {
        try
        {
            _context.CurrentUser = null;
            Console.WriteLine("You successfully logged out!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public string GetInfo()
    {
        return "Log out if already logged in";
    }
}