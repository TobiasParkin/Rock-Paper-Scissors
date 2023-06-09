﻿namespace Rock_Paper_Scissors.Core
{
    using System;
    using Resources.MoveSet;
    using Resources.States;
    using Managers;

    public sealed class Game
    {
        // Thread safe .Net 4 Singleton Design pattern
        private static Lazy<Game> _instance = new Lazy<Game>(() => new Game());

        public static Game Instance
        {
            get => _instance.Value;
        }

        private GameManager _gameManager = GameManager.Instance;

        public bool Initialise()
        {
bool _gameModeChosen = MainMenu();
            // Returns game state
return _gameModeChosen;
        }

        public bool Update()
        {
            switch (_gameManager.GetGameState())
            {
                case GameStates.PlayerVsComputer:
                    PlayerVsComputer();
                    break;
                case GameStates.GameOver:
                    GameOverScreen();
                    return false;
                default:
    MainMenu();
    break;
            }

            return true;
        }

        private bool MainMenu()
        {
            bool _gameOptionIsValid = false;

            while (!_gameOptionIsValid)
            {
                _gameManager.GetGameDialogueInstance().MainMenuDialogue();

                string _gameOption = Console.ReadKey().KeyChar.ToString();

                GameStates _gameState = _gameManager.GetGameState();

                Enum.TryParse(_gameOption, out _gameState);

                _gameOptionIsValid = Enum.IsDefined(typeof(GameStates), _gameState);

_gameManager.SetGameState(_gameState);

                Console.Clear();
            }

            return true;
        }

        private void PlayerVsComputer()
        {
Console.Clear();

            Moves _playerOption;

            Random rnd = new Random();

            _gameManager.GetGameDialogueInstance().PlayerVsComputerScoreText(_gameManager.GetPlayerOneScore(), _gameManager.GetPlayerTwoScore());

            _gameManager.GetGameDialogueInstance().PlayerVsComputerInstructions();
        // Computer has access to moves from value 1 in enum to < total length of enum
            Moves _computerOption = Enum.Parse<Moves>(rnd.Next(1, Enum.GetValues(typeof(Moves)).Length).ToString());

string _playerInput = Console.ReadKey().KeyChar.ToString();

Enum.TryParse(_playerInput, out _playerOption);

if (Enum.IsDefined(typeof(Moves), _playerOption) && _playerOption != Moves.Unselected)
{
    ExectueRound(_playerOption, _computerOption);
            }
        }

        private void ExectueRound(Moves _playerOption, Moves _player2Option)
        {
            PostRoundStates _postRoundState = PostRoundStates.Default;

            _postRoundState = _gameManager.GetRoundOutcome(_playerOption, _player2Option);

_gameManager.AddMoveToMovesUsedTracker(_playerOption);

_gameManager.AddMoveToMovesUsedTracker(_player2Option);

            PostRoundScreen(_postRoundState, _playerOption, _player2Option);
        }

        private void PostRoundScreen(PostRoundStates _postRoundState, Moves _playerMove, Moves _computerMove)
        {
            Console.Clear();
            
_gameManager.GetGameDialogueInstance().PostRoundScreenOutcomeText(_postRoundState);

switch (_postRoundState)
{
    case PostRoundStates.Lose:
        _gameManager.IncrementPlayerTwoScoreByOne();
        break;
    case PostRoundStates.Win:
        _gameManager.IncrementPlayerOneScoreByOne();
        break;
    default:
        break;
}

            _gameManager.IncrementNumberOfRoundsByOne();

            _gameManager.GetGameDialogueInstance().PostRoundScreenText(_playerMove, _computerMove);

            Console.ReadKey();

            if (_gameManager.GetPlayerOneScore() == _gameManager.GetRoundWinCondition() || _gameManager.GetPlayerTwoScore() == _gameManager.GetRoundWinCondition())
            {
                _gameManager.SetGameState(GameStates.GameOver);
            }
        }

        private void GameOverScreen()
        {
            Console.Clear();

            string _winner = _gameManager.CalculateWinner();

            string _numberOfRoundsUsed = _gameManager.GetNumberOfRounds().ToString();

            string _mostUsedMove = _gameManager.CalculateMostUsedMove();

            _gameManager.GetGameDialogueInstance().GameOverScreenText(_winner, _numberOfRoundsUsed, _mostUsedMove);
        }
    }
}
