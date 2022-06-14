namespace BankProject.Commands.AccountCommands
{
    using BankProject.Commands.Interfaces;
    using BankProject.Models.Interfaces;

    public class AddAccountCommand : ICommand
    {
        public string Execute(IBank bank, List<string> arguments)
        {
            string result = bank.AddAccount(arguments);

            return result;
        }
    }
}
