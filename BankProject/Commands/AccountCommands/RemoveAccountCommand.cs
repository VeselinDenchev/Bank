namespace BankProject.Commands.AccountCommands
{
    using BankProject.Commands.Interfaces;
    using BankProject.Models.Interfaces;

    public class RemoveAccountCommand : ICommand
    {
        public string Execute(IBank bank, List<string> arguments)
        {
            string result = bank.RemoveAccount(arguments);

            return result;
        }
    }
}
