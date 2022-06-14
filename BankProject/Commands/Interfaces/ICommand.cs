namespace BankProject.Commands.Interfaces
{
    public interface ICommand
    {
        public abstract string Execute(List<string> arguments = null);
    }
}
