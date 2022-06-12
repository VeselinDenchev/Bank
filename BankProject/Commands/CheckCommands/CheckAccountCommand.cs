namespace BankProject.Commands.CheckCommands
{
    internal class CheckAccountCommand : BankCommand
    {
        public override string Execute(List<string> arguments)
        {
            arguments.Add("Account");
            string result = Bank.Check(arguments);

            return result;
        }
    }
}
