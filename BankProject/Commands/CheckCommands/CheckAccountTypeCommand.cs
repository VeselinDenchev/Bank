using BankProject.Constants;

namespace BankProject.Commands.CheckCommands
{
    public class CheckAccountTypeCommand : CheckCommand
    {
        public override string Execute(List<string> arguments)
        {
            arguments.Add(StringConstant.ACCOUNT_TYPE_CHECK_STRING);

            return base.Execute(arguments);
        }
    }
}
