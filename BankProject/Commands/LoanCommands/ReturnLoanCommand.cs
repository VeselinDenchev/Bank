namespace BankProject.Commands.LoanCommands
{
    internal class ReturnLoanCommand : BankCommand
    {
        public override string Execute(List<string> arguments)
        {
            string result = this.Bank.ReturnLoan(arguments);

            return result;
        }
    }
}
