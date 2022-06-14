namespace BankProject.Commands.LoanCommands
{
    using BankProject.Commands.Interfaces;
    using BankProject.Models.Interfaces;

    internal class DrawLoanCommand : ICommand
    {
        public string Execute(IBank bank, List<string> arguments)
        {
            string result = bank.DrawLoan(arguments);

            return result;
        }
    }
}
