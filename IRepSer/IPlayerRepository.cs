namespace CourseWork;

public interface IPlayerRepository
{
    void AddPlayer (User player);
    void RemovePlayer (User player);
    User? GetPlayer (string username);
    
}