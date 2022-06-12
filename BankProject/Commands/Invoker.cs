namespace BankProject.Commands
{
    using System.Reflection;

    using BankProject.Commands.Interfaces;
    using BankProject.Commands.SystemCommands;
    using BankProject.Singletons;
    using BankProject.Models.Interfaces;
    using BankProject.Models;

    internal static class Invoker
    {
        public static void Run()

        {
            string result = string.Empty;
            string input = null;

            ICommand command = null;
            Assembly assembly = Assembly.GetCallingAssembly();
            Type[] types = assembly.GetTypes();

            while ((input = Console.ReadLine()) != "Shutdown")
            {
                bool isEmpty = input == string.Empty;
                if (isEmpty)
                {
                    continue;
                }

                List<string> arguments = input.Split(' ').ToList();

                string commandName = arguments[0];
                arguments.RemoveAt(0);
                Type commandTypeToExecute = types.FirstOrDefault(t => t.Name == commandName + "Command");

                try
                {
                    if (commandTypeToExecute is null) throw new ArgumentException("Invalid command!" + Environment.NewLine);

                    command = (ICommand)Activator.CreateInstance(commandTypeToExecute);
                    result = command.Execute(arguments);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
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
