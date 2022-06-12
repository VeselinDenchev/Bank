namespace BankProject.Commands.CheckCommands
{
    internal class CheckBalanceCommand : BankCommand
    {
        public override string Execute(List<string> arguments)
        {
            arguments.Add("Balance");
            string result = Bank.Check(arguments);

            return result;
        }
    }
}
