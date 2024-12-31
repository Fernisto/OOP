namespace CourseWork;

public class DbContext
{
    public List<User> Players { get; }
    public List<BasicGame> Games { get; }
    public User? CurrentUser { get; set; }
    
    public DbContext()
    {
        Players = new List<User>();
        Games = new List<BasicGame>();
        this.CurrentUser = CurrentUser;
        Players.Add(new User("John Doe","Password",13));
        Players.Add(new User("ABOBA228","qwerty",13));
        Players.Add(new User("The Marked One","123456",99));
    }
}