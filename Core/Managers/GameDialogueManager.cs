namespace Rock_Paper_Scissors.Core.Managers
{
    using System;
    using Resources.MoveSet;
    using Resources.States;

    public sealed class GameDialogueManager
    {

        private static Lazy<GameDialogueManager> _instance = new Lazy<GameDialogueManager>(() => new GameDialogueManager());

        public static GameDialogueManager Instance
        {
            get => _instance.Value;
        }

        private GameDialogueManager()
        {

        }

        public void MainMenuDialogue()
        {
            Console.WriteLine("Welcome to Rock Paper Scissors" +
                              "\nPlease enter one of the following options - (0 - Player Vs Computer, 1 - Quit)");
        }

        public void PlayerVsComputerInstructions()
        {
            Console.WriteLine("Choose your move (1 - Rock, 2 - Scissors, 3 - Paper, 4 - Spock, 5 - Lizard)");
        }

        public void PlayerVsComputerScoreText(int _playerScore, int _computerScore)
        {
            Console.WriteLine("Player Score: " + _playerScore + " Computer Score: " + _computerScore);
        }

        public void PostRoundScreenText(Moves _playerMove, Moves _computerMove)
        {
            Console.WriteLine("\nPlayer chose: " + _playerMove + " - Computer chose: " + _computerMove + "\nPress Any Key to Start Next Round");
        }

        public void PostRoundScreenOutcomeText(PostRoundStates _postRoundState)
        {
            switch (_postRoundState)
            {
                case PostRoundStates.Tie:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case PostRoundStates.Lose:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case PostRoundStates.Win:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.WriteLine(_postRoundState);

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void GameOverScreenText(string _winner, string _numberOfRounds, string _mostUsedMove)
        {
            Console.WriteLine($"Game Over" +
                              $"\nWinner is ___{_winner}___ " +
                              $"\nThe game took {_numberOfRounds} rounds" +
                              $"\nThe most used move was {_mostUsedMove}");
        }
    }
}
