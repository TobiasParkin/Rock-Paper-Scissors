namespace Rock_Paper_Scissors.Core.Queries
{
    using System.Collections.Generic;
    using Resources.MoveSet;
    using System.Linq;

    public class GetMostUsedMoveFromListOfMoves
    {
        public string Execute(List<Moves> _movesUsed)
        {
            if (_movesUsed.Count() <= 0)
            {
                return "None";
            }

            string _mostUsedMove = _movesUsed.GroupBy(x => x)
                .OrderByDescending(y => y.Count())
                .Select(z => z.Key)
                .FirstOrDefault()
                .ToString();

            return _mostUsedMove;
        }
    }
}
