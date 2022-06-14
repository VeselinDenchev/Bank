namespace BankProject.Memento
{
    using BankProject.Memento.Interfaces;

    public class Memento<T> : IMemento<T>
    {
        public Memento(T state)
        {
            this.State = state;
        }

        public T State { get; init; }
    }
}