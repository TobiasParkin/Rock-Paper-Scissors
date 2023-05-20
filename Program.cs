namespace Rock_Paper_Scissors
{
    using Core;

    class Program
    {
        static void Main(string[] args)
        {
            bool _isGameRunning = true;

            Game game = new Game();

game.Initialise();

            while (_isGameRunning)
            {
                _isGameRunning = game.Update();
            }
        }
    }
}
