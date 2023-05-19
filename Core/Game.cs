namespace Rock_Paper_Scissors.Core
{
    using System;
    using Resources.MoveSet;
    using Resources.Dialogue;
    using Resources.States;
    public class Game
    {
private GameStates _state { get; set; }
private int _playerScore { get; set; }
private int _computerScore { get; set; }

private readonly GameDialogue _gameDialogue = new GameDialogue();

        public void Initialise()
        {
            MainMenu();
        }

        public void Update()
        {
            switch (_state)
            {
                case GameStates.PlayerVsComputer:
                    PlayerVsComputer();
                    break;
                case GameStates.PlayerVsPlayer:
                    PlayerVsPlayer();
                    break;
default:
    break;
            }
        }

        private void MainMenu()
        {
            GameIntro gameIntro = new GameIntro();

            gameIntro.RunIntro();

            Console.WriteLine(_gameDialogue.MainMenuDialogue());

            string _gameOption = Console.ReadKey().KeyChar.ToString();

            _state = Enum.Parse<GameStates>(_gameOption);

Console.Clear();
        }

        private void PlayerVsComputer()
        {
Console.WriteLine("Player vs Computer");

Console.Read();
        }

        private void PlayerVsPlayer()
        {
            Console.WriteLine("Player vs Player");

            Console.Read();
        }
    }
}
