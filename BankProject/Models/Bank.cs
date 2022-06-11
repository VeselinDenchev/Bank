namespace BankProject.Models
{
    using System.Globalization;

    using BankProject.Models.Interfaces;

    internal class Bank : IBank
    {
        public Bank()
        {
            this.Accounts = new List<Account>();
            this.NumberFormat = new CultureInfo("en-US").NumberFormat;
        }

        public List<Account> Accounts { get; set; }

        private NumberFormatInfo NumberFormat { get; init; }

        public string AddAccount(List<string> arguments)
        {
            string output = null;

            switch (arguments.Count)
            {
                case 0:
                    output = "Arguments are missing!";
                    break;

                case 1:
                    output = "Last name and money amount arguments are missing!";
                    break;

                case 2:
                    output = "Balance agurment is missing!";
                    break;

                case 3:
                    string firstName = arguments[0];
                    string lastName = arguments[1];

                    bool isParsed = decimal.TryParse(arguments[2], out decimal balance);
                    if (isParsed)
                    {
                        if (balance >= 0)
                        {
                            Account account = new Account(firstName, lastName, balance);
                            this.Accounts.Add(account);

                            output = "Account is added successfully";
                        }
                        else
                        {
                            output = "A client cannot have negative balance!";
                        }

                    }
                    else
                    {
                        output = "Invalid money ammount format!";
                    }
                    break;

                case > 3:
                    output = "Too many arguments passed!";
                    break;
            }

            output += Environment.NewLine;

            return output;
        }

        public string RemoveAccount(List<string> arguments)
        {
            string output = null;

            switch (arguments.Count)
            {
                case 0:
                    output = "Arguments are missing!";
                    break;

                case 1:
                    output = "Last name argument is missing!";
                    break;

                case 2:
                    string firstName = arguments[0];
                    string lastName = arguments[1];

                    Account account = FindAccountHolder(firstName, lastName);

                    if (account is null)
                    {
                        output = "Such client doesn't exist!";
                    }
                    else
                    {
                        Accounts.Remove(account);
                        output = "Account is successfully removed!";
                    }
                    break;

                case > 2:
                    output = "Too many arguments passed!";
                    break;
            }

            output += Environment.NewLine;

            return output;
        }

        public string DrawFunds(List<string> arguments)
        {
            string output = null;

            switch (arguments.Count)
            {
                case 0:
                    output = "Arguments are missing!";
                    break;

                case 1:
                    output = "Last name and money amount arguments are missing!";
                    break;

                case 2:
                    output = "Money amount agurment is missing!";
                    break;

                case 3:
                    string firstName = arguments[0];
                    string lastName = arguments[1];
                    bool isParsed = decimal.TryParse(arguments[2], out decimal amount);
                    if (isParsed)
                    {
                        if (amount > 0)
                        {
                            Account account = FindAccountHolder(firstName, lastName);

                            try
                            {
                                if (account is null)
                                {
                                    output = "Such client doesn't exist!";
                                }
                                else if (account.Balance > amount)
                                {
                                    account.DrawMoney(amount);
                                    output = string.Format(this.NumberFormat, "Successfully withdrew {0:C} from {1}'s account", 
                                                            amount, account.AccountHolderFullName);
                                }
                                else throw new ArgumentException("Insufficient funds!");
                            }
                            catch (ArgumentException ae)
                            {
                                output = ae.Message;
                            }
                        }
                        else
                        {
                            output = "Cannot draw zero or negative funds!";
                        }
                    }
                    else
                    {
                        output = "Invalid money amount format!";
                    }

                    break;

                case > 4:
                    output = "Too many arguments passed!";
                    break;
            }

            output += Environment.NewLine;

            return output;
        }

        public string RechargeFunds(List<string> arguments)
        {
            string output = null;

            switch (arguments.Count)
            {
                case 0:
                    output = "Arguments are missing!";
                    break;

                case 1:
                    output = "Last name and money amount arguments are missing!";
                    break;

                case 2:
                    output = "Money amount argument is missing!";
                    break;

                case 3:
                    string firstName = arguments[0];
                    string lastName = arguments[1];

                    bool isParsed = decimal.TryParse(arguments[2], out decimal amount);
                    if (isParsed)
                    {
                        if (amount > 0)
                        {
                            Account account = FindAccountHolder(firstName, lastName);

                            if (account is null)
                            {
                                output = "Such client doesn't exist!";
                            }
                            else
                            {
                                account.AddMoney(amount);
                                output = string.Format(this.NumberFormat, "Successfully added {0:C}$ to the {1}'s account", 
                                                        amount, account.AccountHolderFullName);
                            }
                        }
                        else
                        {
                            output = "Cannot recharge account with zero or negative funds!";
                        }
                    }
                    else
                    {
                        output = "Invalid money amount format!";
                    }

                    break;

                case > 3:
                    output = "Too many arguments passed!";
                    break;
            }

            output += Environment.NewLine;

            return output;
        }

        public string DrawLoan(List<string> arguments)
        {
            string output = null;

            switch (arguments.Count)
            {
                case 0:
                    output = "Arguments are missing!";
                    break;

                case 1:
                    output = "Last name, money amount and years to return arguments are missing!";
                    break;

                case 2:
                    output = "Money amount and years to return arguments are missing!";
                    break;

                case 3:
                    output = "Years to return argument is missing!";
                    break;

                case 4:
                    string firstName = arguments[0];
                    string lastName = arguments[1];
                    bool moneyIsParsed = decimal.TryParse(arguments[2], out decimal moneyAmmount);
                    bool yearsAreParsed = int.TryParse(arguments[3], out int yearsToReturn);
                    if (moneyIsParsed && yearsAreParsed)
                    {
                        if (moneyAmmount > 0 && yearsToReturn > 0)
                        {
                            Account account = FindAccountHolder(firstName, lastName);

                            if (account is null)
                            {
                                output = "Such client doesn't exist!";
                            }
                            else
                            {
                                account.AddMoney(moneyAmmount);

                                Loan loan = new Loan(account.AccountType, moneyAmmount, yearsToReturn);
                                account.Loans.Add(loan);

                                output =    string.Format(this.NumberFormat, "Successfully drawn a {0:C} loan", moneyAmmount) + 
                                            Environment.NewLine +
                                            string.Format(this.NumberFormat, "The client must return {0:C} to the bank after", 
                                            loan.AmmountToReturn) 
                                            + Environment.NewLine +
                                            $"{yearsToReturn} years!";
                            }

                        }
                        else if (moneyAmmount < 0 && yearsToReturn < 0)
                        {
                            output = "Money ammount and years to return cannot be negative!";
                        }
                        else if (moneyAmmount < 0)
                        {
                            output = "Cannot draw zero or negative funds!";
                        }
                        else if (yearsToReturn < 0)
                        {
                            output = "Years to return cannot be zero or negative!";
                        }
                    }
                    else if (!moneyIsParsed && !yearsAreParsed)
                    {
                        output = "Invalid money amount and years to return format!";
                    }
                    else if (!moneyIsParsed)
                    {
                        output = "Invalid money format!";
                    }
                    else if (!yearsAreParsed)
                    {
                        output = "Invalid year to return format!";
                    }

                    break;

                case > 4:
                    output = "Too many arguments passed!";
                    break;
            }

            output += Environment.NewLine;

            return output;
        }

        public string ReturnLoan(List<string> arguments)
        {
            string output = null;

            switch (arguments.Count)
            {
                case 0:
                    output = "Arguments are missing!";
                    break;

                case 1:
                    output = "Last name and money amount arguments are missing!";
                    break;

                case 2:
                    output = "Money amount argument is missing!";
                    break;

                case 3:
                    string firstName = arguments[0];
                    string lastName = arguments[1];

                    bool moneyIsParsed = decimal.TryParse(arguments[2], out decimal ammount);
                    if (moneyIsParsed)
                    {
                        if (ammount > 0)
                        {
                            Account account = FindAccountHolder(firstName, lastName);

                            if (account is null)
                            {
                                output = "Such client doesn't exist!";
                            }
                            else
                            {
                                Loan loanToBeReturned = FindLoan(account.Loans, ammount);

                                try
                                {
                                    if (loanToBeReturned is null)
                                    {
                                        output = "Such loan doesn't exist!";
                                    }
                                    else
                                    {
                                        try
                                        {
                                            if (account.Balance < loanToBeReturned.AmmountToReturn)
                                            {
                                                throw new OperationCanceledException("Account balance is less than the loan return " +
                                                                                        "ammount! Transaction canceled!");
                                            }
                                            else
                                            {
                                                account.DrawMoney(loanToBeReturned.AmmountToReturn);

                                                output =    $"Successfully returned the loan" + Environment.NewLine +
                                                            string.Format(this.NumberFormat, 
                                                            "The client returned total of {0:C} to the", loanToBeReturned.AmmountToReturn) +
                                                            $" bank after {loanToBeReturned.YearsToReturn} years!";
                                            }
                                        }
                                        catch (OperationCanceledException oce)
                                        {
                                            output = oce.Message;
                                        }

                                    }
                                }
                                catch (InvalidDataException ide)
                                {
                                    output = ide.Message;
                                }
                            }
                        }
                        else
                        {
                            output = "Cannot draw zero or negative funds!";
                        }
                    }
                    else
                    {
                        output = "Invalid money format!";
                    }
                    break;

                case > 3:
                    output = "Too many arguments passed!";
                    break;
            }

            output += Environment.NewLine;

            return output;
        }

        public string Check(List<string> arguments)
        {
            string output = null;

            switch (arguments.Count)
            {
                case 2:
                    output = "Last name is missing!";
                    break;

                case 3:
                    string firstName = arguments[0];
                    string lastName = arguments[1];

                    Account account = FindAccountHolder(firstName, lastName);

                    if (account is null)
                    {
                        output = "Such client doesn't exist!";
                    }
                    else
                    {
                        string checkTypeString = arguments[2];

                        switch (checkTypeString)
                        {
                            case "Balance":
                                output = $"{account.AccountHolderFullName} balance is {account.Balance}$";
                                break;

                            case "AccountType":
                                output = $"{account.AccountHolderFullName} account's type is {account.AccountTypeName}";
                                break;

                            case "Account":
                                output = account.ToString();
                                break;
                        }
                    }
                    break;

                case > 3:
                    output = "Too many arguments passed!";
                    break;
            }
            output += Environment.NewLine;

            return output;
        }

        public string Shutdown()
        {
            string output = "Shutting down...";

            return output;
        }

        private Account FindAccountHolder(string firstName, string lastName)
        {
            Account account = Accounts.Where(a => a.FirstName == firstName && a.LastName == lastName)
                                        .FirstOrDefault();

            return account;
        }

        private Loan FindLoan(List<Loan> loans, decimal ammount)
        {
            foreach (Loan loan in loans)
            {
                bool isMatched = loan.DrawnAmmount == ammount;
                if (isMatched) return loan;
            }

            return null;
        }
    }
}