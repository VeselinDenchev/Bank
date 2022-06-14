namespace BankProject.Commands.SystemCommands
{
    using BankProject.Constants;

    public class UndoCommand : BankCommand
    {
        public override string Execute(List<string> arguments)
        {
            this.Bank.RevertSnapshot(out bool isSuccessful);

            string result = null;

            if (isSuccessful)
            {
                result = MessageConstant.SUCCESSFULLY_UNDO_LAST_COMMAND_MESSAGE;
            }
            else
            {
                result = MessageConstant.NOTHING_TO_UNDO_MESSAGE;
            }

            return result;
        }
    }
}
