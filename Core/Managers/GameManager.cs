namespace Rock_Paper_Scissors.Core.Managers
{
    using System;
    using System.Collections.Generic;
    using Resources.MoveSet;
    using Resources.States;
    using System.Linq;

    public sealed class GameManager
    {
        // Thread safe .Net 4 Singleton Design pattern
        private static Lazy<GameManager> _instance = new Lazy<GameManager>(() => new GameManager());

        public static GameManager Instance
        {
            get => _instance.Value;
        }

        private int _playerOneScore { get; set; }
        private int _playerTwoScore { get; set; }
        private int _numberOfRounds { get; set; }
        private GameStates _state { get; set; }

        private List<Moves> _movesUsed = new List<Moves>();

        private readonly GameDialogueManager _gameDialogue = GameDialogueManager.Instance;

        private readonly RulesManager _rulesManager = RulesManager.Instance;

        private GameManager()
        {

        }

        public int GetPlayerOneScore()
        {
            return _playerOneScore;
        }

        public int GetPlayerTwoScore()
        {
            return _playerTwoScore;
        }

        public int GetNumberOfRounds()
        {
            return _numberOfRounds;
        }

        public List<Moves> GetMovesUsedList()
        {
            return _movesUsed;
        }

        public void AddMoveToMovesUsedTracker(Moves _move)
        {
            _movesUsed.Add(_move);
        }

        public GameStates GetGameState()
        {
            return _state;
        }

        public GameDialogueManager GetGameDialogueInstance()
        {
            return _gameDialogue;
        }

        public void SetGameState(GameStates _newState)
        {
            _state = _newState;
        }

        public void IncrementPlayerOneScoreByOne()
        {
            ++_playerOneScore;
        }

        public void IncrementPlayerTwoScoreByOne()
        {
            ++_playerTwoScore;
        }

        public void IncrementNumberOfRoundsByOne()
        {
            ++_numberOfRounds;
        }

        public string CalculateWinner()
        {
            return _playerTwoScore > _playerOneScore ? "Computer" :
                _playerOneScore != _playerTwoScore ? "Player" : "No-one it was a Tie";
        }

        public string CalculateMostUsedMove()
        {
            string _mostUsedMove = _movesUsed.GroupBy(x => x)
                .OrderByDescending(y => y.Key)
                .Select(z => z.Key)
                .FirstOrDefault()
                .ToString();

            _mostUsedMove = _movesUsed.Count > 0 ? _mostUsedMove : "None";

            return _mostUsedMove;
        }

        public PostRoundStates GetRoundOutcome(Moves _playerOneMove, Moves _playerTwoMove)
        {
            return _rulesManager.GetMoveOutcome(_playerOneMove, _playerTwoMove);
        }

        public void ShowPostRoundScreen(PostRoundStates _postRoundState)
        {
            _gameDialogue.PostRoundScreenOutcomeText(_postRoundState);
        }
    }
}
