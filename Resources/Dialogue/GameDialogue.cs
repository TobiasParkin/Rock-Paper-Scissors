using System;

namespace Rock_Paper_Scissors.Resources.Dialogue
{
    using MoveSet;
    public class GameDialogue
    {
        public void MainMenuDialogue()
        {
            Console.WriteLine("Welcome to Rock Paper Scissors" +
                              "\nPlease enter one of the following options - (0 - Player Vs Computer, 1 - Quit)"); 
        }

        public void PlayerVsComputerInstructions()
        {
            Console.WriteLine("Choose your move (1 - Rock, 2 - Scissors, 3 - Paper)");
        }

        public void PlayerVsComputerScoreText(int _playerScore, int _computerScore)
        {
            Console.WriteLine("Player Score: " + _playerScore + " Computer Score: " + _computerScore);
        }

        public void PostRoundScreenText(Moves _playerMove, Moves _computerMove)
        {
            Console.WriteLine("\nPlayer chose: " + _playerMove + " - Computer chose: " + _computerMove + "\nPress Any Key to Start Next Round");
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
