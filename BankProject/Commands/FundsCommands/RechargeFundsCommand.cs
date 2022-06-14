namespace BankProject.Commands.FundsCommands
{
    public class RechargeFundsCommand : BankCommand
    {
        public override string Execute(List<string> arguments)
        {
            string result = this.Bank.RechargeFunds(arguments);

            return result;
        }
    }
}
