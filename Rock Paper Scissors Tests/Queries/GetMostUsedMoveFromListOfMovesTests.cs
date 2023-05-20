namespace Rock_Paper_Scissors_Tests.Queries
{
    using Rock_Paper_Scissors.Core.Queries;
    using Rock_Paper_Scissors.Resources.MoveSet;
    public class GetMostUsedMoveFromListOfMovesTests
    {
        [Fact]
        public void ExecuteReturnsNone()
        {
            var _query = new GetMostUsedMoveFromListOfMoves();

            var _listOfUsedMoves = new List<Moves>() { };

            var _result = _query.Execute(_listOfUsedMoves);

            var _expectedResult = "None";

            Assert.Equal(_expectedResult, _result);
        }

        [Fact]
        public void ExecuteReturnsRock()
        {
            var _query = new GetMostUsedMoveFromListOfMoves();

            var _listOfUsedMoves = new List<Moves>() {Moves.Rock, Moves.Rock, Moves.Paper, Moves.Paper, Moves.Lizard, Moves.Rock, Moves.Scissors, Moves.Spock};

            var _result = _query.Execute(_listOfUsedMoves);

            var _expectedResult = "Rock";

            Assert.Equal(_expectedResult, _result);
        }
    }
}