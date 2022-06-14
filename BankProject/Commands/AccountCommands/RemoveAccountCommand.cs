namespace BankProject.Commands.AccountCommands
{
    public class RemoveAccountCommand : BankCommand
    {
        public override string Execute(List<string> arguments)
        {
            string result = this.Bank.RemoveAccount(arguments);

            return result;
        }
    }
}
