namespace BankProject.Commands.AccountCommands
{
    internal class AddAccountCommand : BankCommand
    {
        public override string Execute(List<string> arguments)
        {
            string result = Bank.AddAccount(arguments);

            return result;
        }
    }
}
