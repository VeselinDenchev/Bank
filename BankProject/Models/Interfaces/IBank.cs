namespace BankProject.Models.Interfaces
{
    using BankProject.Memento.Interfaces;

    public interface IBank : IOriginator<IBank>
    {
        public List<IAccount> Accounts { get; set; }

        public string AddAccount(List<string> arguments);

        public string RemoveAccount(List<string> arguments);

        public string DrawFunds(List<string> arguments);

        public string RechargeFunds(List<string> arguments);

        public string DrawLoan(List<string> arguments);

        public string ReturnLoan(List<string> arguments);

        public string Check(List<string> arguments);

        public string Shutdown();

        public Stack<IMemento<IBank>> MementosStack { get; set; }

        public void CreateSnapshot();

        public void RevertSnapshot(out bool isSuccessful);
    }
}
