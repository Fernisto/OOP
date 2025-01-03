namespace CourseWork;

public class GetStats:ICommand
{
    private readonly IPlayerService _userService;
    private readonly DbContext _context;
    public GetStats(IPlayerService userService, DbContext context)
    {
        _userService = userService;
        _context = context;
    }
    public void Execute()
    {
        var currentplayer = _context.CurrentUser;
        _userService.GetStats(currentplayer.username);
    }

    public string GetInfo()
    {
        return "Shows stats for user";
    }
}