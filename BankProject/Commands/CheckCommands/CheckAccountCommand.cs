namespace BankProject.Commands.CheckCommands
{
    using BankProject.Constants;

    public class CheckAccountCommand : CheckCommand
    {
        public override string Execute(List<string> arguments)
        {
            arguments.Add(StringConstant.ACCOUNT_CHECK_STRING);

            return base.Execute(arguments);
        }
    }
}
