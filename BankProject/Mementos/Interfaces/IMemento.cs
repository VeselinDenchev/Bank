namespace BankProject.Mementos.Interfaces
{
    public interface IMemento<T>
    {
        public T State { get; init; }
    }
}