namespace BankProject.Prototypes.Interfaces
{
    public interface IPrototype<T>
    {
        public T Clone();
    }
}