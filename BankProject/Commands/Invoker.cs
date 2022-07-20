namespace BankProject.Commands
{
    using System.Reflection;

    using BankProject.Commands.Interfaces;
    using BankProject.Commands.SystemCommands;
    using BankProject.Constants;
    using BankProject.Models;
    using BankProject.Models.Interfaces;

    public class Invoker : IInvoker
    {
        public Invoker()
        {
            this.Bank = new Bank();
        }

        public IBank Bank { get; init; }

        private ICommand Command { get; set; }

        public void Run()
        {
            string result = string.Empty;
            string input = null;

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
                    if (commandTypeToExecute is null) throw new ArgumentException(MessageConstant.INVALID_COMMAND_MESSAGE);

                    try
                    {
                        this.Command = (ICommand)Activator.CreateInstance(commandTypeToExecute);
                        result = this.Command.Execute(this.Bank, arguments);
                    }
                    catch (MissingMethodException)
                    {
                        result = MessageConstant.INVALID_COMMAND_MESSAGE;

                    }
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

            this.Command = new ShutdownCommand(); 
            result = this.Command.Execute(this.Bank);
            Console.WriteLine(result);
        }
    }
}
