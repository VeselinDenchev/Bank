namespace BankProject.Commands.CheckCommands
{
    using BankProject.Constants;
    using BankProject.Models.Interfaces;

    public class CheckAccountCommand : CheckCommand
    {
        public override string Execute(IBank bank, List<string> arguments)
        {
            arguments.Add(StringConstant.ACCOUNT_CHECK_STRING);

            return base.Execute(bank, arguments);
        }
    }
}
