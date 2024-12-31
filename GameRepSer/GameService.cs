namespace CourseWork;

public class GameService : IGameService
{
    public IGameRepository Repository { get; set; }

    public GameService(IGameRepository repository)
    {
        this.Repository = repository;
    }

    public BasicGame? GetGame(int gameId)
    {
        return Repository.GetGame(gameId);
    }

    public void AddGame(BasicGame game)
    {
        if (Repository.GetGame(game.GameId) != null)
        {
            throw new Exception($"Game {game.GameId} already exists");
        }
        Repository.AddGame(game);
    }

    public void CreateGame(int gametype, User player1, User player2, int rating)
    {
        
        BasicGame game = gametype switch
        {
            1 => GameFactory.CreateRankedGame(rating, player1, player2),
            2 => GameFactory.CreateTrainingGame(player1, player2),
            _ => throw new ArgumentException("Invalid game type")
        };

        game.Play();
        Repository.AddGame(game);
        
        player1.AddGameToHistory(game);
        player2.AddGameToHistory(game);

        Console.WriteLine($"Game saved: {game.PlayerName} against {game.OpponentName} - Won: {game.GameResult}");
    }
}