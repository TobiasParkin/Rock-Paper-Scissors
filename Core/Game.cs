
using System.Linq;

namespace Rock_Paper_Scissors.Core
{
    using System;
    using System.Collections.Generic;
    using Resources.MoveSet;
    using Resources.Dialogue;
    using Resources.States;
    public class Game
    {
        private GameStates _state;
        private List<Moves> _movesUsed = new List<Moves>();
        private int _playerScore { get; set; }
private int _computerScore { get; set; }
private int _numberOfRounds { get; set; }

private readonly GameDialogue _gameDialogue = new GameDialogue();

        public bool Initialise()
        {
bool _gameModeChosen = MainMenu();

return _gameModeChosen;
        }

        public bool Update()
        {
            switch (_state)
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
            GameIntro gameIntro = new GameIntro();

            gameIntro.RunIntro();

            bool _gameOptionIsValid = false;

            while (!_gameOptionIsValid)
            {
                Console.WriteLine(_gameDialogue.MainMenuDialogue());

                string _gameOption = Console.ReadKey().KeyChar.ToString();

                _gameOptionIsValid = Enum.TryParse(_gameOption, out _state);

                Console.Clear();
            }

            return true;
        }

        private void PlayerVsComputer()
        {
            Console.Clear();

            PostRoundStates _postRoundState = PostRoundStates.Default;

            Random rnd = new Random();

Moves _computerOption = Enum.Parse<Moves>(rnd.Next(0, 3).ToString());

Console.WriteLine(_gameDialogue.PlayerVsComputerScoreText(_playerScore, _computerScore));

            Console.WriteLine(_gameDialogue.PlayerVsComputerInstructions());

string _playerInput = Console.ReadKey().KeyChar.ToString();

            Moves _playerOption = Enum.Parse<Moves>(_playerInput);

            if (_computerOption == _playerOption)
            {
                _postRoundState = PostRoundStates.Tie;
            }

            switch (_playerOption)
            {
                case Moves.Rock:
                     if (_computerOption == Moves.Scissors)
                     {
                         _postRoundState = PostRoundStates.Win;
                     }
                    else if (_computerOption == Moves.Paper)
                    {
                        _postRoundState = PostRoundStates.Lose;
                    }
                    break;
                case Moves.Scissors:
if (_computerOption == Moves.Rock)
                    {
                        _postRoundState = PostRoundStates.Lose;
                    }
                    else if (_computerOption == Moves.Paper)
                    {
                        _postRoundState = PostRoundStates.Win;
                    }
                    break;
                case Moves.Paper:
                     if (_computerOption == Moves.Rock)
                    {
                        _postRoundState = PostRoundStates.Win;
                    }
                    else if (_computerOption == Moves.Scissors)
                     {
                         _postRoundState = PostRoundStates.Lose;
                     }
                    break;
                default:
                    break;
            }

            if (Enum.IsDefined(typeof(Moves), _playerOption))
            {
                _movesUsed.Add(_playerOption);

                _movesUsed.Add(_computerOption);

                PostRoundScreen(_postRoundState, _playerOption, _computerOption);
            }
        }

        private void PostRoundScreen(PostRoundStates _postRoundState, Moves _playerMove, Moves _computerMove)
        {
            Console.Clear();

            switch (_postRoundState)
            {
                case PostRoundStates.Tie:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(_postRoundState);
                    ++_numberOfRounds;
                    break;
                case PostRoundStates.Lose:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(_postRoundState);
                    ++_computerScore;
                    ++_numberOfRounds;
                    break;
                case PostRoundStates.Win:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(_postRoundState);
                    ++_playerScore;
                    ++_numberOfRounds;
                    break;
default:
    break;
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(_gameDialogue.PostRoundScreenText(_playerMove, _computerMove));

            Console.ReadKey();
        }

        private void GameOverScreen()
        {
            Console.Clear();

            string _winner = _computerScore > _playerScore ? "Computer" :
                _computerScore != _playerScore ? "Player" : "No-one it was a Tie";

            string _mostUsedMove = _movesUsed.GroupBy(x => x)
                    .OrderByDescending(y => y)
                    .Select(z => z.Key)
                                    .FirstOrDefault()
                    .ToString();

            _mostUsedMove = _movesUsed.Count > 0 ? _mostUsedMove : "None";

Console.WriteLine(_gameDialogue.GameOverScreenText(_winner, _numberOfRounds.ToString(), _mostUsedMove));
        }
    }
}
