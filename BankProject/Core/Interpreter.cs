namespace BankProject.Core
{
    using BankProject.Models;
    using BankProject.Models.Interfaces;

    internal class Interpreter
    {
        public static void Run()

        {
            string result = string.Empty;
            string input = null;

            IBank bank = new Bank();

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
                            result = bank.AddAccount(arguments);
                            break;

                        case "RemoveAccount":
                            result = bank.RemoveAccount(arguments);
                            break;

                        case "DrawFunds":
                            result = bank.DrawFunds(arguments);
                            break;

                        case "RechargeFunds":
                            result = bank.RechargeFunds(arguments);
                            break;

                        case "DrawLoan":
                            result = bank.DrawLoan(arguments);
                            break;

                        case "ReturnLoan":
                            result = bank.ReturnLoan(arguments);
                            break;

                        case "CheckBalance":
                            arguments.Add("Balance");
                            result = bank.Check(arguments);
                            break;

                        case "CheckAccountType":
                            arguments.Add("AccountType");
                            result = bank.Check(arguments);
                            break;

                        case "CheckAccount":
                            arguments.Add("Account");
                            result = bank.Check(arguments);
                            break;

                        default:
                            throw new ArgumentException("Invalid command!" + Environment.NewLine);
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

            result = bank.Shutdown();
            Console.WriteLine(result);
        }
    }
}
