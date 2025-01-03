namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DbContext();
            var gameRepository = new GameRepository(context);
            var playerRepository = new PlayerRepository(context);
            var gameService = new GameService(gameRepository);
            var playerService = new PlayerService(playerRepository,context);
            var commandHandler = new CommandHandler(playerService, gameService, context);

            Console.WriteLine("Welcome to the Game!");
            commandHandler.Start();
        }
    }
}
