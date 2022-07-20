namespace BankProject.Models
{
    using System.Globalization;

    using BankProject.Constants;
    using BankProject.Mementos;
    using BankProject.Mementos.Interfaces;
    using BankProject.Models.Interfaces;
    using BankProject.Prototypes;

    public sealed class Bank : BankPrototype, IBank, IOriginator<Bank>, ISnapshot
    {
        public Bank()
            : base()
        {
            this.NumberFormat = new CultureInfo(StringConstant.ENGLISH_UNITED_STATES_CULTURE_STRING).NumberFormat;
        }

        private NumberFormatInfo NumberFormat { get; init; }

        public string AddAccount(List<string> arguments)
        {
            string output = null;

            switch (arguments.Count)
            {
                case 0:
                    output = MessageConstant.MISSING_ARGUMENTS_MESSAGE;
                    break;

                case 1:
                    output = MessageConstant.MISSING_LAST_NAME_AND_MONEY_AMOUNT_ARGUMENTS_MESSAGE;
                    break;

                case 2:
                    output = MessageConstant.MISSING_BALANCE_ARGUMENT_MESSAGE;
                    break;

                case 3:
                    string firstName = arguments[0];
                    string lastName = arguments[1];

                    bool isParsed = decimal.TryParse(arguments[2], out decimal balance);
                    if (isParsed)
                    {
                        if (balance >= 0)
                        {
                            IAccount account = new Account(firstName, lastName, balance, this.NumberFormat);
                            this.CreateSnapshot();

                            this.Accounts.Add(account);

                            output = MessageConstant.ACCOUNT_ADDED_SUCCESSFULLY_MESSAGE;
                        }
                        else
                        {
                            output = MessageConstant.NEGATIVE_BALANCE_MESSAGE;
                        }

                    }
                    else
                    {
                        output = MessageConstant.INVALID_MONEY_AMOUNT_FORMAT_MESSAGE;
                    }
                    break;

                case > 3:
                    output = MessageConstant.TOO_MANY_ARGUMENTS_PASSED_MESSAGE;
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
                    output = MessageConstant.MISSING_ARGUMENTS_MESSAGE;
                    break;

                case 1:
                    output = MessageConstant.MISSING_LAST_NAME_ARGUMENT_MESSAGE;
                    break;

                case 2:
                    string firstName = arguments[0];
                    string lastName = arguments[1];

                    IAccount account = FindAccountHolder(firstName, lastName);

                    if (account is null)
                    {
                        output = MessageConstant.ACCOUNT_DOES_NOT_EXIST_MESSAGE;
                    }
                    else
                    {
                        this.CreateSnapshot();

                        Accounts.Remove(account);
                        output = MessageConstant.ACCOUNT_SUCCESSFULLY_REMOVED_MESSAGE;
                    }
                    break;

                case > 2:
                    output = MessageConstant.TOO_MANY_ARGUMENTS_PASSED_MESSAGE;
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
                    output = MessageConstant.MISSING_ARGUMENTS_MESSAGE;
                    break;

                case 1:
                    output = MessageConstant.MISSING_LAST_NAME_AND_MONEY_AMOUNT_ARGUMENTS_MESSAGE;
                    break;

                case 2:
                    output = MessageConstant.MISSING_MONEY_AMOUNT_ARGUMENT_MESSAGE;
                    break;

                case 3:
                    string firstName = arguments[0];
                    string lastName = arguments[1];
                    bool isParsed = decimal.TryParse(arguments[2], out decimal amount);
                    if (isParsed)
                    {
                        if (amount > 0)
                        {
                            IAccount account = FindAccountHolder(firstName, lastName);

                            try
                            {
                                if (account is null)
                                {
                                    output = MessageConstant.ACCOUNT_DOES_NOT_EXIST_MESSAGE;
                                }
                                else if (account.Balance > amount)
                                {
                                    this.CreateSnapshot();

                                    account.DrawMoney(amount);
                                    output = string.Format(this.NumberFormat, 
                                                            MessageConstant.SUCCESSFULLY_WITHDREW_MONEY_FROM_ACCOUNT_MESSAGE, 
                                                            amount, account.AccountHolderFullName);
                                }
                                else throw new ArgumentException(MessageConstant.INSUFFICIENT_FUND_MESSAGE);
                            }
                            catch (ArgumentException ae)
                            {
                                output = ae.Message;
                            }
                        }
                        else
                        {
                            output = MessageConstant.CANNOT_DRAW_ZERO_OR_NEGATIVE_FUNDS_MESSAGE;
                        }
                    }
                    else
                    {
                        output = MessageConstant.INVALID_MONEY_AMOUNT_FORMAT_MESSAGE;
                    }

                    break;

                case > 4:
                    output = MessageConstant.TOO_MANY_ARGUMENTS_PASSED_MESSAGE;
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
                    output = MessageConstant.MISSING_ARGUMENTS_MESSAGE;
                    break;

                case 1:
                    output = MessageConstant.MISSING_LAST_NAME_AND_MONEY_AMOUNT_ARGUMENTS_MESSAGE;
                    break;

                case 2:
                    output = MessageConstant.MISSING_MONEY_AMOUNT_ARGUMENT_MESSAGE;
                    break;

                case 3:
                    string firstName = arguments[0];
                    string lastName = arguments[1];

                    bool isParsed = decimal.TryParse(arguments[2], out decimal amount);
                    if (isParsed)
                    {
                        if (amount > 0)
                        {
                            IAccount account = FindAccountHolder(firstName, lastName);

                            if (account is null)
                            {
                                output = MessageConstant.ACCOUNT_DOES_NOT_EXIST_MESSAGE;
                            }
                            else
                            {
                                this.CreateSnapshot();

                                account.AddMoney(amount);
                                output = string.Format(this.NumberFormat, MessageConstant.SUCCESSFULLY_ADDED_MONEY_TO_ACCOUNT_MESSAGE, 
                                                        amount, account.AccountHolderFullName, account.Balance);
                            }
                        }
                        else
                        {
                            output = MessageConstant.CANNOT_RECHARGE_ACCOUNT_WITH_ZERO_OR_NEGATIVE_FUNDS;
                        }
                    }
                    else
                    {
                        output = MessageConstant.INVALID_MONEY_AMOUNT_FORMAT_MESSAGE;
                    }

                    break;

                case > 3:
                    output = MessageConstant.TOO_MANY_ARGUMENTS_PASSED_MESSAGE;
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
                    output = MessageConstant.MISSING_ARGUMENTS_MESSAGE;
                    break;

                case 1:
                    output = MessageConstant.MISSING_LAST_NAME_MONEY_AMOUNT_AND_YEAR_TO_RETURN_ARGUMENTS_MESSAGE;
                    break;

                case 2:
                    output = MessageConstant.MISSING_MONEY_AMOUNT_AND_YEARS_TO_RETURN_ARGUMENTS_MESSAGE;
                    break;

                case 3:
                    output = MessageConstant.MISSING_YEARS_TO_RETURN_ARGUMENTS_MESSAGE;
                    break;

                case 4:
                    string firstName = arguments[0];
                    string lastName = arguments[1];
                    bool moneyIsParsed = decimal.TryParse(arguments[2], out decimal moneyAmmount);
                    bool yearsAreParsed = byte.TryParse(arguments[3], out byte yearsToReturn);
                    if (moneyIsParsed && yearsAreParsed)
                    {
                        if (moneyAmmount > 0 && yearsToReturn > 0)
                        {
                            IAccount account = FindAccountHolder(firstName, lastName);

                            if (account is null)
                            {
                                output = MessageConstant.ACCOUNT_DOES_NOT_EXIST_MESSAGE;
                            }
                            else
                            {
                                this.CreateSnapshot();

                                ILoan loan = new Loan(moneyAmmount, account.AccountType, yearsToReturn, this.NumberFormat);
                                account.DrawLoan(loan);

                                output = string.Format(this.NumberFormat, MessageConstant.SUCCESSFULLY_DRAWN_LOAN_MESSAGE, 
                                                        moneyAmmount, loan.AmountToReturn, yearsToReturn);
                            }

                        }
                        else if (moneyAmmount <= 0 && yearsToReturn <= 0)
                        {
                            output = MessageConstant.MONEY_AMOUNT_AND_YEARS_TO_RETURN_CANNOT_BE_NEGATIVE_OR_ZERO_MESSAGE;
                        }
                        else if (moneyAmmount <= 0)
                        {
                            output = MessageConstant.CANNOT_DRAW_ZERO_OR_NEGATIVE_FUNDS_MESSAGE;
                        }
                        else if (yearsToReturn <= 0)
                        {
                            output = MessageConstant.YEARS_TO_RETURN_MUST_BE_POSITIVE;
                        }
                    }
                    else if (!moneyIsParsed && !yearsAreParsed)
                    {
                        output = MessageConstant.INVALID_MONEY_AMOUNT_AND_YEARS_TO_RETURN_FORMAT_MESSAGE;
                    }
                    else if (!moneyIsParsed)
                    {
                        output = MessageConstant.INVALID_MONEY_AMOUNT_FORMAT_MESSAGE;
                    }
                    else if (!yearsAreParsed)
                    {
                        output = MessageConstant.INVALID_YEARS_TO_RETURN_FORMAT_MESSAGE;
                    }

                    break;

                case > 4:
                    output = MessageConstant.TOO_MANY_ARGUMENTS_PASSED_MESSAGE;
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
                    output = MessageConstant.MISSING_ARGUMENTS_MESSAGE;
                    break;

                case 1:
                    output = MessageConstant.MISSING_LAST_NAME_AND_MONEY_AMOUNT_ARGUMENTS_MESSAGE;
                    break;

                case 2:
                    output = MessageConstant.MISSING_MONEY_AMOUNT_ARGUMENT_MESSAGE;
                    break;

                case 3:
                    string firstName = arguments[0];
                    string lastName = arguments[1];

                    bool moneyIsParsed = decimal.TryParse(arguments[2], out decimal ammount);
                    if (moneyIsParsed)
                    {
                        if (ammount > 0)
                        {
                            IAccount account = FindAccountHolder(firstName, lastName);

                            if (account is null)
                            {
                                output = MessageConstant.ACCOUNT_DOES_NOT_EXIST_MESSAGE;
                            }
                            else
                            {
                                ILoan loanToBeReturned = FindLoan(account.Loans, ammount);

                                if (loanToBeReturned is null)
                                {
                                    output = MessageConstant.LOAN_DOES_NOT_EXIST_MESSAGE;
                                }
                                else
                                {
                                    try
                                    {
                                        if (account.Balance < loanToBeReturned.AmountToReturn)
                                        {
                                            throw new OperationCanceledException(
                                                        MessageConstant.ACCOUNT_BALANCE_LOWER_THAN_LOAN_RETURN_AMOUNT_MESSAGE);
                                        }
                                        else
                                        {
                                            this.CreateSnapshot();

                                            account.ReturnLoan(loanToBeReturned);

                                            output = string.Format(this.NumberFormat, MessageConstant.SUCCESSFULLY_RETURNED_LOAN_MESSAGE,
                                                                    loanToBeReturned.AmountToReturn, loanToBeReturned.YearsToReturn);
                                        }
                                    }
                                    catch (OperationCanceledException oce)
                                    {
                                        output = oce.Message;
                                    }
                                }
                            }
                        }
                        else
                        {
                            output = MessageConstant.CANNOT_DRAW_ZERO_OR_NEGATIVE_FUNDS_MESSAGE;
                        }
                    }
                    else
                    {
                        output = MessageConstant.INVALID_MONEY_AMOUNT_FORMAT_MESSAGE;
                    }
                    break;

                case > 3:
                    output = MessageConstant.TOO_MANY_ARGUMENTS_PASSED_MESSAGE;
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
                case < 2:
                    output = MessageConstant.MISSING_FIRST_NAME_AND_LAST_NAME_ARGUMENTS;
                    break;

                case 2:
                    output = MessageConstant.MISSING_LAST_NAME_ARGUMENT_MESSAGE;
                    break;

                case 3:
                    string firstName = arguments[0];
                    string lastName = arguments[1];

                    IAccount account = FindAccountHolder(firstName, lastName);

                    if (account is null)
                    {
                        output = MessageConstant.ACCOUNT_DOES_NOT_EXIST_MESSAGE;
                    }
                    else
                    {
                        string checkTypeString = arguments[2];

                        switch (checkTypeString)
                        {
                            case StringConstant.BALANCE_CHECK_STRING:
                                output = string.Format(this.NumberFormat, MessageConstant.BALANCE_MESSAGE, 
                                                        account.AccountHolderFullName, account.Balance);
                                break;

                            case StringConstant.ACCOUNT_TYPE_CHECK_STRING:
                                output = string.Format(MessageConstant.ACCOUNT_TYPE_MESSAGE, account.AccountHolderFullName,
                                                        account.AccountType.ToString());
                                break;

                            case StringConstant.ACCOUNT_CHECK_STRING:
                                output = account.ToString();
                                break;
                        }
                    }
                    break;

                case > 3:
                    output = MessageConstant.TOO_MANY_ARGUMENTS_PASSED_MESSAGE;
                    break;
            }
            output += Environment.NewLine;

            return output;
        }

        public string Shutdown()
        {
            string result = MessageConstant.SHUTDOWN_MESSAGE;

            return result;
        }

        private IAccount FindAccountHolder(string firstName, string lastName)
        {
            IAccount account = Accounts.Where(a => a.FirstName == firstName && a.LastName == lastName)
                                        .FirstOrDefault();

            return account;
        }

        private Loan FindLoan(List<ILoan> loans, decimal ammount)
        {
            foreach (Loan loan in loans)
            {
                bool exists = loan.DrawnAmount == ammount;
                if (exists) return loan;
            }

            return null;
        }

        public IMemento<Bank> SaveMemento() => new Memento<Bank>(this.State);

        public void RestoreMemento(IMemento<Bank> memento) => this.Accounts = memento.State.Accounts;

        public void CreateSnapshot()
        {
            Bank copyBank = (Bank)this.Clone();
            this.State = copyBank;

            IMemento<Bank> newMemento = this.SaveMemento();
            this.MementosStack.Push(newMemento);
        }

        public void RevertSnapshot(out bool isSuccessful)
        {
            isSuccessful = this.MementosStack.TryPop(out IMemento<Bank> newMemento);

            if (isSuccessful)
            {
                this.RestoreMemento(newMemento);
            }
        }

        public override BankPrototype Clone()
        {
            BankPrototype copyBank = (Bank)this.MemberwiseClone();

            copyBank.Accounts = new List<IAccount>(this.Accounts.Count);
            for (int i = 0; i < this.Accounts.Count; i++)
            {
                IAccount currentAccount = this.Accounts[i];

                List<ILoan> copyLoans = new List<ILoan>(currentAccount.Loans.Count);

                for (int j = 0; j < currentAccount.Loans.Count; j++)
                {
                    ILoan currentLoan = currentAccount.Loans[j];

                    ILoan currentLoanCopy = new Loan(currentLoan.Id, currentLoan.DrawnAmount, currentLoan.InterestRate, currentLoan.YearsToReturn,
                                                        this.NumberFormat);

                    copyLoans.Add(currentLoanCopy);
                }

                IAccount currentAccountCopy = new Account(currentAccount.FirstName, currentAccount.LastName, currentAccount.Id,
                                                    currentAccount.Balance, copyLoans, this.NumberFormat);

                copyBank.Accounts.Add(currentAccountCopy);
            }

            return copyBank;
        }
    }
}