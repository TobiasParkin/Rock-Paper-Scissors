namespace Rock_Paper_Scissors.Core.Managers
{
    using System;
    using System.Collections.Generic;
    using Resources.MoveSet;
    using Resources.States;

    public sealed class RulesManager
    {
        // Thread safe .Net 4 Singleton Design pattern
        private static Lazy<RulesManager> _instance = new Lazy<RulesManager>(() => new RulesManager());

        public static RulesManager Instance
        {
            get => _instance.Value;
        }

        // Dictionary of Move and list of moves weak too
        private static readonly Dictionary<Moves, List<Moves>> _rules = new Dictionary<Moves, List<Moves>>
        {
            {Moves.Rock, new List<Moves> {Moves.Paper, Moves.Spock}},
            {Moves.Paper, new List<Moves> {Moves.Scissors, Moves.Lizard}},
            {Moves.Scissors, new List<Moves> {Moves.Rock, Moves.Spock}},
            {Moves.Spock, new List<Moves> {Moves.Lizard, Moves.Paper}},
            {Moves.Lizard, new List<Moves> {Moves.Rock, Moves.Scissors}}
        };

        private RulesManager()
        {

        }

        public PostRoundStates GetMoveOutcome(Moves _playerOneMove, Moves _playerTwoMove)
        {
            if (_playerOneMove == _playerTwoMove)
            {
                return PostRoundStates.Tie;
            }

            if (_rules[_playerOneMove].Contains(_playerTwoMove))
            {
                return PostRoundStates.Lose;
            }

            return PostRoundStates.Win;
        }
    }
}
