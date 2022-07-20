namespace BankProject.Mementos.Interfaces
{
    public interface ISnapshot
    {
        public void CreateSnapshot();

        public void RevertSnapshot(out bool isSuccessful);
    }
}
