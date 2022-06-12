namespace BankProject.Commands.Interfaces
{
    internal interface ICommand
    {
        public abstract string Execute(List<string> arguments = null);
    }
}
