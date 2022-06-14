namespace BankProject.Commands.FundsCommands
{
    public class DrawFundsCommand : BankCommand
    {
        public override string Execute(List<string> arguments)
        {
            string result = this.Bank.DrawFunds(arguments);

            return result;
        }
    }
}
