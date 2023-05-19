namespace Rock_Paper_Scissors.Core.Moveset
{ 
using Interface;
    public class Scissors : IMove
    {
        public IMove[] WeakAgainst
{
    get { return new IMove[] { new Rock() };} 
set {}
}
public IMove[] StrongAgainst { get; set; }
    }
}
