namespace BattleArena
{
    public interface ISubject
    {
        void Subscribe(IObserver observer);
        void Alert();
    }
}
