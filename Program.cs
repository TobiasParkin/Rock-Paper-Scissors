namespace Rock_Paper_Scissors
{
    using Core;

    class Program
    {
        static void Main(string[] args)
        {

            Game game = Game.Instance;

            // Initialise Game
            bool _isGameRunning = game.Initialise();

            while (_isGameRunning)
            {
        // Main Game Loop
                _isGameRunning = game.Update();
            }
        }
    }
}
