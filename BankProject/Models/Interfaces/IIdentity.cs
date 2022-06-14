namespace BankProject.Models.Interfaces
{
    public interface IIdentity<T>
    {
        public T Id { get; init; }
    }
}
