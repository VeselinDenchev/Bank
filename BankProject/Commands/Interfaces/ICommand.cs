namespace BankProject.Commands.Interfaces
{
    using BankProject.Models.Interfaces;

    public interface ICommand
    {
        public abstract string Execute(IBank bank, List<string> arguments = null);
    }
}
