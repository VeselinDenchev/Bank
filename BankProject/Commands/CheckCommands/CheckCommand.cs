namespace BankProject.Commands.CheckCommands
{
    using BankProject.Commands.Interfaces;
    using BankProject.Models.Interfaces;

    public abstract class CheckCommand : ICommand
    {
        public virtual string Execute(IBank bank, List<string> arguments)
        {
            string result = bank.Check(arguments);

            return result;
        }
    }
}
