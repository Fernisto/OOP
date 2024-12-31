namespace CourseWork;

public interface IGameService
{
    BasicGame? GetGame(int id);
    void AddGame(BasicGame game);
    
    void CreateGame(int gametype, User player, User opponent, int rating );
}