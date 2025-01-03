namespace CourseWork;

public interface IPlayerService
{
    User? GetPlayer(string username);
    void AddPlayer(User player);
    bool RegisterPlayer(User player);
    bool Login(string username, string password);
    void GetStats(string currentplayerUsername);
}