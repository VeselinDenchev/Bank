namespace EvilBank.Models
{
    internal static class Bank
    {
        public static List<Account> Accounts = new List<Account>();

        public static string AddAccount(List<string> arguments) 
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

                    bool isParsed = Decimal.TryParse(arguments[2], out decimal balance);
                    if (isParsed)
                    {
                        if (balance >= 0)
                        {
                            Account account = new Account(firstName, lastName, balance);
                            Accounts.Add(account);

                            output = "Account is added successfully!";
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

        public static string RemoveAccount(List<string> arguments)
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
                        try
                        {
                            throw new NullReferenceException("Such client doesn't exist");
                        }
                        catch (NullReferenceException nre)
                        {
                            output = nre.Message;
                        }
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

        public static string DrawFunds(List<string> arguments)
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
                    bool isParsed = Decimal.TryParse(arguments[2], out decimal amount);
                    if (isParsed)
                    {
                        if (amount > 0)
                        {
                            Account account = FindAccountHolder(firstName, lastName);

                            try
                            {
                                if (account is null)
                                {
                                    throw new NullReferenceException("Such client doesn't exist!");
                                }
                                else if (account.Balance > amount)
                                {
                                    account.DrawMoney(amount);
                                    output = $"Successfully withdrew {amount}$ from {account.AccountHolder}'s account";
                                }
                                else
                                {
                                    throw new ArgumentException("Insufficient funds!");
                                }
                            }
                            catch (Exception e)
                            {
                                output = e.Message;
                            }

                            break;
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

        public static string RechargeFunds(List<string> arguments) 
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

                    bool isParsed = Decimal.TryParse(arguments[2], out decimal amount);
                    if (isParsed)
                    {
                        if (amount > 0)
                        {
                            Account account = FindAccountHolder(firstName, lastName);

                            try
                            {
                                if (account is null)
                                {
                                    throw new InvalidDataException("Such client doesn't exist!");
                                }
                                else
                                {
                                    //AccountType accountType = new AccountType(account);
                                    account.AddMoney(amount);
                                    output = $"Successfully added {amount}$ to the {account.AccountHolder}'s account";
                                }
                            }
                            catch (InvalidDataException ide)
                            {
                                output = ide.Message;
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

        public static string DrawLoan(List<string> arguments)
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
                    bool moneyIsParsed = Decimal.TryParse(arguments[2], out decimal moneyAmmount);
                    bool yearsAreParsed = int.TryParse(arguments[3], out int yearsToReturn);
                    if (moneyIsParsed && yearsAreParsed)
                    {
                        if (moneyAmmount > 0 && yearsToReturn > 0)
                        {
                            Account account = FindAccountHolder(firstName, lastName);
                            if (account is null)
                            {
                                try
                                {
                                    throw new NullReferenceException("Such client doesn't exist!");
                                }
                                catch (NullReferenceException nre)
                                {
                                    output = nre.Message;
                                }
                            }
                            else
                            {
                                //AccountType accountType = new AccountType(account);
                                account.AddMoney(moneyAmmount);

                                Loan loan = new Loan(account.AccountType, moneyAmmount, yearsToReturn);
                                account.Loans.Add(loan);

                                output = $"Successfully drawn a {moneyAmmount}$ loan" + Environment.NewLine +
                                                    $"The client must return {loan.AmmountToReturn}$ to the bank after" +
                                                    $" {yearsToReturn} years!" +
                                                    Environment.NewLine;
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

        public static string ReturnLoan(List<string> arguments)
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

                    bool moneyIsParsed = Decimal.TryParse(arguments[2], out decimal ammount);
                    if (moneyIsParsed)
                    {
                        if (ammount > 0)
                        {
                            Account account = FindAccountHolder(firstName, lastName);

                            if (account is null)
                            {
                                try
                                {
                                    throw new NullReferenceException("Such client doesn't exist");
                                }
                                catch (NullReferenceException nre)
                                {
                                    output = nre.Message;
                                }
                            }
                            else
                            {
                                Loan loanToBeReturned = FindLoan(account, ammount);

                                try
                                {
                                    if (loanToBeReturned is null)
                                    {
                                        throw new InvalidDataException("Such loan doesn't exist!");
                                    }
                                    else
                                    {
                                        try
                                        {
                                            if (account.Balance < loanToBeReturned.AmmountToReturn)
                                            {
                                                throw new OperationCanceledException("Account balance is less than the loan return ammount! " +
                                                                                        "Transaction canceled!");
                                            }
                                            else
                                            {
                                                //AccountType accountType = new AccountType(account);
                                                account.DrawMoney(loanToBeReturned.AmmountToReturn);

                                                output = $"Successfully returned a {ammount}$ loan" + Environment.NewLine +
                                                    $"The client returned total of  {loanToBeReturned.AmmountToReturn}$ to the bank " +
                                                    $"after {loanToBeReturned.YearsToReturn} years!" +
                                                    Environment.NewLine;
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

        public static string Check(List<string> arguments)
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
                        try
                        {
                            throw new NullReferenceException("Such client doesn't exist");
                        }
                        catch (NullReferenceException nre)
                        {
                            output = nre.Message;
                        }
                    }
                    else
                    {
                        string checkTypeString = arguments[2];

                        if (checkTypeString == "Balance")
                        {
                            output = $"{firstName} {lastName} balance is {account.Balance}$";
                        }
                        else if (checkTypeString == "AccountType")
                        {
                            output = $"{firstName} {lastName} account type is {account.AccountTypeName}";
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

        public static string Shutdown()
        {
            string output = "Shutting down...";

            return output;
        }

        private static Account FindAccountHolder(string firstName, string lastName)
        {
            Account account = Accounts.Where(a => a.Owner.FirstName == firstName && a.Owner.LastName == lastName)
                                        .FirstOrDefault();

            return account;
        }

        private static Loan FindLoan(Account account, decimal ammount)
        {
            foreach (Loan loan in account.Loans)
            {
                bool isMatched = loan.DrawnAmmount == ammount;

                if (isMatched)
                {
                    return loan;
                }
            }

            return null;
        }
    }
}