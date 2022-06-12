namespace BankProject.Commands.CheckCommands
{
    internal class CheckAccountTypeCommand : BankCommand
    {
        public override string Execute(List<string> arguments)
        {
            arguments.Add("AccountType");
            string result = Bank.Check(arguments);

            return result;
        }
    }
}
