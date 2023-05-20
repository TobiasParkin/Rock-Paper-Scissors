namespace Rock_Paper_Scissors.Resources.Dialogue
{
    using MoveSet;
    public class GameDialogue
    {
        public string MainMenuDialogue()
        {
            return "Welcome to Rock Paper Scissors" +
                   "\nPlease enter one of the following options - (0 - Player Vs Computer, 1 - Quit)";
        }

        public string PlayerVsComputerInstructions()
        {
            return "Choose your move (1 - Rock, 2 - Scissors, 3 - Paper)";
        }

        public string PlayerVsComputerScoreText(int _playerScore, int _computerScore)
        {
            return "Player Score: " + _playerScore + " Computer Score: " + _computerScore;
        }

        public string PostRoundScreenText(Moves _playerMove, Moves _computerMove)
        {
            return "\nPlayer chose: " + _playerMove + " - Computer chose: " + _computerMove + "\nPress Any Key to Start Next Round";
        }

        public string GameOverScreenText(string _winner, string _numberOfRounds, string _mostUsedMove)
        {
            return $"Game Over" +
                $"\nWinner is ___{_winner}___ " +
                $"\nThe game took {_numberOfRounds} rounds" +
                $"\nThe most used move was {_mostUsedMove}";
        }
    }
}
