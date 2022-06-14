namespace BankProject.Commands
{
    using BankProject.Commands.Interfaces;
    using BankProject.Models;
    using BankProject.Models.Interfaces;
    using BankProject.Singleton;

    public abstract class BankCommand : ICommand
    {
        public BankCommand()
        {
            this.Bank = ISingleton<Bank>.Instance;
        }

        public IBank Bank { get; init; }

        public abstract string Execute(List<string> arguments);
    }
}
