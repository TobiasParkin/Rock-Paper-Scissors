using Rock_Paper_Scissors.Core.Managers;
using Rock_Paper_Scissors.Resources.States;

namespace Rock_Paper_Scissors_Tests.Core.Managers
{
    using Rock_Paper_Scissors.Resources.MoveSet;
    public class RulesManagerTests
    {
        [Fact]
        public void GetMoveOutcomeReturnsTie()
        {
            var _playerOneMoveMoq = Moves.Lizard;

            var _playerTwoMoveMoq = Moves.Lizard;

RulesManager _rulesManager = RulesManager.Instance;

var _result = _rulesManager.GetMoveOutcome(_playerOneMoveMoq, _playerTwoMoveMoq);

var _expectedResult = PostRoundStates.Tie;

Assert.Equal(_expectedResult, _result);
        }

        [Fact]
        public void GetMoveOutcomeReturnsWin()
        {
            var _playerOneMoveMoq = Moves.Rock;

            var _playerTwoMoveMoq = Moves.Lizard;

            RulesManager _rulesManager = RulesManager.Instance;

            var _result = _rulesManager.GetMoveOutcome(_playerOneMoveMoq, _playerTwoMoveMoq);

            var _expectedResult = PostRoundStates.Win;

            Assert.Equal(_expectedResult, _result);
        }

        [Fact]
        public void GetMoveOutcomeReturnsLose()
        {
            var _playerOneMoveMoq = Moves.Paper;

            var _playerTwoMoveMoq = Moves.Lizard;

            RulesManager _rulesManager = RulesManager.Instance;

            var _result = _rulesManager.GetMoveOutcome(_playerOneMoveMoq, _playerTwoMoveMoq);

            var _expectedResult = PostRoundStates.Lose;

            Assert.Equal(_expectedResult, _result);
        }
    }
}
