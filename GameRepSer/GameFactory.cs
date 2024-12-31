namespace CourseWork;

public class GameFactory
{
    public static BasicGame CreateRankedGame(int rating, User player1, User player2)
    {
        var game = GameEngine.GameBetween(player1, player2, rating);
        if (game == null)
        {
            throw new Exception("Game can not be created");
        }

        return game;
    }

    public static BasicGame CreateTrainingGame(User player1, User player2)
    {
        var game = GameEngine.GameBetween(player1, player2,0);
        if (game == null)
        {
            throw new Exception("Game can not be created");
        }

        return game;
    }
}