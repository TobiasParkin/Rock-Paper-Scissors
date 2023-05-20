namespace Rock_Paper_Scissors_Tests.Queries
{
    using Rock_Paper_Scissors.Core.Queries;
    using Rock_Paper_Scissors.Resources.MoveSet;
    public class GetMostUsedMoveFromListOfMovesTests
    {

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { new List<Moves> {}, "None" };
            yield return new object[] { new List<Moves> { Moves.Rock, Moves.Rock, Moves.Paper, Moves.Paper, Moves.Lizard, Moves.Rock, Moves.Scissors, Moves.Spock }, "Rock" };
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ExecuteReturnsExpected(List<Moves> _listOfUsedMoves, string _expectedResult)
        {
            var _query = new GetMostUsedMoveFromListOfMoves();

            var _result = _query.Execute(_listOfUsedMoves);

            Assert.Equal(_expectedResult, _result);
        }
    }
}