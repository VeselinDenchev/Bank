namespace BankProject.Mementos
{
    using BankProject.Mementos.Interfaces;

    public class Memento<T> : IMemento<T>
    {
        public Memento(T state)
        {
            this.State = state;
        }

        public T State { get; init; }
    }
}