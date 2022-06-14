namespace BankProject.Commands.CheckCommands
{
    using BankProject.Constants;
    using BankProject.Models.Interfaces;

    public class CheckAccountTypeCommand : CheckCommand
    {
        public override string Execute(IBank bank, List<string> arguments)
        {
            arguments.Add(StringConstant.ACCOUNT_TYPE_CHECK_STRING);

            return base.Execute(bank, arguments);
        }
    }
}
