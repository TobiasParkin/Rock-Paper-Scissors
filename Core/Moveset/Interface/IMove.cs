namespace Rock_Paper_Scissors.Core.Moveset.Interface
{
    public interface IMove
    {
        public IMove[] WeakAgainst { get; set; }
        public IMove[] StrongAgainst { get; set; }
    }
}
