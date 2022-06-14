namespace BankProject.Memento.Interfaces
{
    public interface IMemento<T>
    {
        public T State { get; init; }
    }
}