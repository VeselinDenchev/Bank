namespace BankProject.Commands.SystemCommands
{
    public class ShutdownCommand : BankCommand
    {
        public override string Execute(List<string> arguments = null)
        {
            string result = this.Bank.Shutdown();

            return result;
        }
    }
}
