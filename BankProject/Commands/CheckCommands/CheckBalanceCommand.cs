namespace BankProject.Commands.CheckCommands
{
    using BankProject.Constants;

    public class CheckBalanceCommand : CheckCommand
    {
        public override string Execute(List<string> arguments)
        {
            arguments.Add(StringConstant.BALANCE_CHECK_STRING);

            return base.Execute(arguments);
        }
    }
}
