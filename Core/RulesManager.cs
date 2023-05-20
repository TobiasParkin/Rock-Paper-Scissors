using Rock_Paper_Scissors.Resources.States;
using System;
using System.Collections.Generic;
using Rock_Paper_Scissors.Resources.MoveSet;

namespace Rock_Paper_Scissors.Core
{
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
            {Moves.Rock, new List<Moves> {Moves.Paper}},
            {Moves.Paper, new List<Moves> {Moves.Scissors}},
            {Moves.Scissors, new List<Moves> {Moves.Rock}}
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

            if(_rules[_playerOneMove].Contains(_playerTwoMove))
            {
                return PostRoundStates.Lose;
            }

            return PostRoundStates.Win;
        }
    }
}
