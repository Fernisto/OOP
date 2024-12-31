namespace CourseWork;

public class PlayerRepository: IPlayerRepository
{
    public DbContext Context { get; }

    public PlayerRepository(DbContext context)
    {
        this.Context = context;
    }
    public void AddPlayer(User player)
    {
        Context.Players.Add(player);
    }

    public void RemovePlayer(User player)
    {
        Context.Players.Remove(player);
    }



    public User? GetPlayer(string username)
    {
        return Context.Players.Find(x => x.username == username);
    }
}