namespace BankProject.Models.Interfaces
{
    public interface IBank
    {
        public string AddAccount(List<string> arguments);

        public string RemoveAccount(List<string> arguments);

        public string DrawFunds(List<string> arguments);

        public string RechargeFunds(List<string> arguments);

        public string DrawLoan(List<string> arguments);

        public string ReturnLoan(List<string> arguments);

        public string Check(List<string> arguments);

        public string Shutdown();
    }
}
