namespace BankProject.Commands.SystemCommands
{
    using BankProject.Commands.Interfaces;

    internal class ShutdownCommand : ICommand
    {
        public string Execute(List<string> arguments)
        {
            string result = "Shutting down...";

            return result;
        }
    }
}
