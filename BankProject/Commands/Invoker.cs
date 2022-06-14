namespace BankProject.Commands
{
    using System.Reflection;

    using BankProject.Commands.Interfaces;
    using BankProject.Commands.SystemCommands;
    using BankProject.Constants;

    public class Invoker : IInvoker
    {
        public void Run()
        {
            string result = string.Empty;
            string input = null;

            ICommand command = null;

            Assembly assembly = Assembly.GetCallingAssembly();
            Type[] types = assembly.GetTypes();

            while ((input = Console.ReadLine()) != CommandConstant.SHUTDOWN_COMMAND_STRING)
            {
                bool isEmpty = input == string.Empty;
                if (isEmpty)
                {
                    continue;
                }

                List<string> arguments = input.Split(' ').ToList();

                string commandName = arguments[0];
                arguments.RemoveAt(0);

                Type commandTypeToExecute = types.FirstOrDefault(t => t.Name == commandName + CommandConstant.COMMAND_SUFFIX);

                try
                {
                    if (commandTypeToExecute is null) throw new ArgumentException(MessageConstant.INVALID_COMMAND_MESSAGE + Environment.NewLine);

                    command = (ICommand)Activator.CreateInstance(commandTypeToExecute);
                    result = command.Execute(arguments);
                }
                catch (ArgumentException ae)
                {
                    result = ae.Message;
                }

                if (result is not null)
                {
                    Console.WriteLine(result);
                    result = null;
                }
            }

            command = new ShutdownCommand(); 
            result = command.Execute();
            Console.WriteLine(result);
        }
    }
}
