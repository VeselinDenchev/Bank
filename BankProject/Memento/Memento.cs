using BankProject.Memento.Interfaces;

namespace BankProject.Memento
{
    public class Memento<T> : IMemento<T>
    {
        public Memento(T state)
        {
            this.State = state;
        }

        public T State { get; init; }
    }
}