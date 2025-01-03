namespace CourseWork;

public class GameStats:ICommand
{
    private readonly IPlayerService _userService;

    public GameStats(IPlayerService userService)
    {
        _userService = userService;
    }

    public void Execute()
    {
        
    }

    public string GetInfo()
    {
        throw new NotImplementedException();
    }
}