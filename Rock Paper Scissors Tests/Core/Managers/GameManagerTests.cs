namespace Rock_Paper_Scissors_Tests.Core.Managers
{
    using Rock_Paper_Scissors.Core.Managers;
    using Rock_Paper_Scissors.Resources.MoveSet;
    using Rock_Paper_Scissors.Resources.States;
    public class GameManagerTests
    {
        [Fact]
        public void GetRoundOutcomeReturnsTie()
        {
            var _playerOneMoveMoq = Moves.Lizard;

            var _playerTwoMoveMoq = Moves.Lizard;

            GameManager _gameManager = GameManager.Instance;

            var _result = _gameManager.GetRoundOutcome(_playerOneMoveMoq, _playerTwoMoveMoq);

            var _expectedResult = PostRoundStates.Tie;

            Assert.Equal(_expectedResult, _result);
        }

        [Fact]
        public void GetRoundOutcomeReturnsWin()
        {
            var _playerOneMoveMoq = Moves.Rock;

            var _playerTwoMoveMoq = Moves.Lizard;

            GameManager _gameManager = GameManager.Instance;

            var _result = _gameManager.GetRoundOutcome(_playerOneMoveMoq, _playerTwoMoveMoq);

            var _expectedResult = PostRoundStates.Win;

            Assert.Equal(_expectedResult, _result);
        }

        [Fact]
        public void GetRoundOutcomeReturnsLose()
        {
            var _playerOneMoveMoq = Moves.Paper;

            var _playerTwoMoveMoq = Moves.Lizard;

            GameManager _gameManager = GameManager.Instance;

            var _result = _gameManager.GetRoundOutcome(_playerOneMoveMoq, _playerTwoMoveMoq);

            var _expectedResult = PostRoundStates.Lose;

            Assert.Equal(_expectedResult, _result);
        }
    }
}
