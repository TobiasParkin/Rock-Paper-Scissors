namespace Rock_Paper_Scissors_Tests.Core.Managers
{
    using Rock_Paper_Scissors.Resources.MoveSet;
    using Rock_Paper_Scissors.Core.Managers;
    using Rock_Paper_Scissors.Resources.States;

    public class RulesManagerTests
    {
        [Theory]
        [InlineData(Moves.Lizard, Moves.Lizard, PostRoundStates.Tie)]
        [InlineData(Moves.Rock, Moves.Lizard, PostRoundStates.Win)]
        [InlineData(Moves.Paper, Moves.Lizard, PostRoundStates.Lose)]
        public void GetMoveOutcomeReturnsTie(Moves _playerOneMoveMoq, Moves _playerTwoMoveMoq,
            PostRoundStates _expectedResult)
        {
            RulesManager _rulesManager = RulesManager.Instance;

            var _result = _rulesManager.GetMoveOutcome(_playerOneMoveMoq, _playerTwoMoveMoq);

            Assert.Equal(_expectedResult, _result);
        }
    }
}
