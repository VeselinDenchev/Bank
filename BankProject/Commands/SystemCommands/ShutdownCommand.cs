namespace BankProject.Commands.SystemCommands
{
    using BankProject.Commands.Interfaces;
    using BankProject.Models.Interfaces;

    public class ShutdownCommand : ICommand
    {
        public string Execute(IBank bank, List<string> arguments = null)
        {
            string result = bank.Shutdown();

            return result;
        }
    }
}
