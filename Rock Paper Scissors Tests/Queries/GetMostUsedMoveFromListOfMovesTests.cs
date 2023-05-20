namespace Rock_Paper_Scissors_Tests.Queries
{
    using Rock_Paper_Scissors.Core.Queries;
    using Rock_Paper_Scissors.Resources.MoveSet;
    public class GetMostUsedMoveFromListOfMovesTests
    {
        [Fact]
        public void ExecuteReturnsNone()
        {
            var query = new GetMostUsedMoveFromListOfMoves();

            var listOfUsedMoves = new List<Moves>() { };

            var result = query.Execute(listOfUsedMoves);

            var expectedResult = "None";

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ExecuteReturnsRock()
        {
            var query = new GetMostUsedMoveFromListOfMoves();

            var listOfUsedMoves = new List<Moves>() {Moves.Rock, Moves.Rock, Moves.Paper, Moves.Paper, Moves.Lizard, Moves.Rock, Moves.Scissors, Moves.Spock};

            var result = query.Execute(listOfUsedMoves);

            var expectedResult = "Rock";

            Assert.Equal(expectedResult, result);
        }
    }
}