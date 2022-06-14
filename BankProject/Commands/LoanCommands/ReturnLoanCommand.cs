namespace BankProject.Commands.LoanCommands
{
    using BankProject.Commands.Interfaces;
    using BankProject.Models.Interfaces;

    internal class ReturnLoanCommand : ICommand
    {
        public string Execute(IBank bank, List<string> arguments)
        {
            string result = bank.ReturnLoan(arguments);

            return result;
        }
    }
}
