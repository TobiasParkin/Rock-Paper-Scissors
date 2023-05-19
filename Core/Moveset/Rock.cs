namespace Rock_Paper_Scissors.Core.Moveset
{
    using Interface;
    internal class Rock : IMove
    {
        public IMove[] WeakAgainst
        {
            get;
            set;
        }

        public IMove[] StrongAgainst
        {
            get { return new IMove[] { new Scissors() }; }
set {}
            
        }
    }
}
