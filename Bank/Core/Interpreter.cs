using EvilBank.Models;

namespace EvilBank.Core
{
    internal class Interpreter
    {
        public static void Run()
        
        {
            string result = string.Empty;
            string input = null;

            while ((input = Console.ReadLine()) != "Shutdown")
            {
                bool isEmpty = input == string.Empty;

                if (isEmpty)
                {
                    continue;
                }

                List<string> arguments = input.Split(' ').ToList();

                string command = arguments[0];
                arguments.RemoveAt(0);

                try
                {
                    switch (command)
                    {
                        case "AddAccount":
                            result = Bank.AddAccount(arguments);
                            break;

                        case "RemoveAccount":
                            result = Bank.RemoveAccount(arguments);
                            break;

                        case "DrawFunds":
                            result = Bank.DrawFunds(arguments);
                            break;

                        case "RechargeFunds":
                            result = Bank.RechargeFunds(arguments);
                            break;

                        case "DrawLoan":
                            result = Bank.DrawLoan(arguments);
                            break;


                        case "ReturnLoan":
                            result = Bank.ReturnLoan(arguments);
                            break;

                        case "CheckBalance":
                            arguments.Add("Balance");
                            result = Bank.Check(arguments);
                            break;

                        case "CheckAccountType":
                            arguments.Add("AccountType");
                            result = Bank.Check(arguments);
                            break;

                        default:
                            throw new ArgumentException("Invalid command!");
                            break;
                    }
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
            result = Bank.Shutdown();

            Console.WriteLine(result);
            
        }
    }
}
