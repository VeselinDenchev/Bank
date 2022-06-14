namespace BankProject.Commands.FundsCommands
{
    using BankProject.Commands.Interfaces;
    using BankProject.Models.Interfaces;

    public class RechargeFundsCommand : ICommand
    {
        public string Execute(IBank bank, List<string> arguments)
        {
            string result = bank.RechargeFunds(arguments);

            return result;
        }
    }
}
