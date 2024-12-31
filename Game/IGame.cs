namespace CourseWork;

public interface IGame
{
    int GameId { get; }
    string PlayerName { get; }
    string OpponentName { get; }
    string GameResult { get; }
    int Rating { get; }

    void Play();
}