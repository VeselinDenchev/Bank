namespace BankProject.Commands.LoanCommands
{
    internal class DrawLoanCommand : BankCommand
    {
        public override string Execute(List<string> arguments)
        {
            string result = this.Bank.DrawLoan(arguments);

            return result;
        }
    }
}
