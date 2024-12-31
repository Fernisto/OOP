namespace CourseWork;

public interface IGameRepository
{
    void AddGame (BasicGame game);
    BasicGame? GetGame (int id);

}