namespace BankProject.Prototypes.Interfaces
{
    public interface IPrototype<T> where T : class
    {
        public T Clone();
    }
}