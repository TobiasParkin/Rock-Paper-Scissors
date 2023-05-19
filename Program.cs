namespace Rock_Paper_Scissors
{
    using Core;

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

game.Initialise();

            while (true)
            {
                game.Update();
            }
        }
    }
}
