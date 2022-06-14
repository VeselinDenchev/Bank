namespace BankProject.Commands.FundsCommands
{
    using BankProject.Commands.Interfaces;
    using BankProject.Models.Interfaces;

    public class DrawFundsCommand : ICommand
    {
        public string Execute(IBank bank, List<string> arguments)
        {
            string result = bank.DrawFunds(arguments);

            return result;
        }
    }
}
