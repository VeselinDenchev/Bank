namespace BankProject.Commands.AccountCommands
{
    internal class RemoveAccountCommand : BankCommand
    {
        public override string Execute(List<string> arguments)
        {
            string result = this.Bank.RemoveAccount(arguments);

            return result;
        }
    }
}
