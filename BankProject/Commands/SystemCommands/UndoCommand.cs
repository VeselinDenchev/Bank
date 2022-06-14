namespace BankProject.Commands.SystemCommands
{
    using BankProject.Commands.Interfaces;
    using BankProject.Constants;
    using BankProject.Models.Interfaces;

    public class UndoCommand : ICommand
    {
        public string Execute(IBank bank, List<string> arguments = null)
        {
            bank.RevertSnapshot(out bool isSuccessful);

            string result = null;

            if (isSuccessful)
            {
                result = MessageConstant.SUCCESSFULLY_UNDID_LAST_COMMAND_MESSAGE;
            }
            else
            {
                result = MessageConstant.NOTHING_TO_UNDO_MESSAGE;
            }

            return result;
        }
    }
}
