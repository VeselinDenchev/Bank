namespace BankProject.Commands.CheckCommands
{
    public abstract class CheckCommand : BankCommand
    {
        public override string Execute(List<string> arguments)
        {
            string result = Bank.Check(arguments);

            return result;
        }
    }
}
