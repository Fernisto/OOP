namespace CourseWork;

public class GameRepository: IGameRepository
{
    public DbContext Context { get; set; }
    
    public GameRepository(DbContext context)
    {
        this.Context = context;
    }
    
    public void AddGame(BasicGame game)
    {
        Context.Games.Add(game);
    }

    public void RemoveGame(BasicGame game)
    {
        Context.Games.Remove(game);
    }

    public void UpdateGame(BasicGame game)
    {
        return;
    }

    public BasicGame? GetGame(int id)
    {
        return Context.Games.Find(x => x.GameId == id);
    }
}