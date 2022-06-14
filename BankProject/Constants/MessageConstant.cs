namespace BankProject.Constants
{
    public static class MessageConstant
    {
        // MISSING ARGUMENT MESSAGES
        public const string MISSING_ARGUMENTS_MESSAGE = "Arguments are missing!";

        public const string MISSING_LAST_NAME_AND_MONEY_AMOUNT_ARGUMENTS_MESSAGE = "Last name and money amount arguments are missing!";

        public const string MISSING_BALANCE_ARGUMENT_MESSAGE = "Balance argument is missing!";

        public const string MISSING_LAST_NAME_ARGUMENT_MESSAGE = "Last name argument is missing!";

        public const string MISSING_MONEY_AMOUNT_ARGUMENT_MESSAGE = "Money amount agurment is missing!";

        public const string MISSING_LAST_NAME_MONEY_AMOUNT_AND_YEAR_TO_RETURN_ARGUMENTS_MESSAGE =
                        "Last name, money amount and years to return arguments are missing!";

        public const string MISSING_MONEY_AMOUNT_AND_YEARS_TO_RETURN_ARGUMENTS_MESSAGE =
                                "Money amount and years to return arguments are missing!";

        public const string MISSING_YEARS_TO_RETURN_ARGUMENTS_MESSAGE = "Years to return argument is missing!";

        public const string MISSING_FIRST_NAME_AND_LAST_NAME_ARGUMENTS = "First name and last name arguments are missing!";


        // ACCOUNT MESSAGES
        public const string ACCOUNT_ADDED_SUCCESSFULLY_MESSAGE = "Account is added successfully";

        public const string ACCOUNT_DOES_NOT_EXIST_MESSAGE = "Such account doesn't exist!";

        public const string ACCOUNT_SUCCESSFULLY_REMOVED_MESSAGE = "Account is successfully removed!";

        public const string BALANCE_MESSAGE = "{0}'s balance is {1:C}";

        public const string ACCOUNT_TYPE_MESSAGE = "{0} account's type is {1}";


        // MONEY MESSAGES
        public const string SUCCESSFULLY_WITHDREW_MONEY_FROM_ACCOUNT_MESSAGE = "Successfully withdrew {0:C} from {1}'s account";

        public const string INSUFFICIENT_FUND_MESSAGE = "Insufficient funds!";

        public const string CANNOT_DRAW_ZERO_OR_NEGATIVE_FUNDS_MESSAGE = "Cannot draw zero or negative funds!";

        public const string SUCCESSFULLY_ADDED_MONEY_TO_ACCOUNT_MESSAGE = "Successfully added {0:C} to the {1}'s account";

        public const string CANNOT_RECHARGE_ACCOUNT_WITH_ZERO_OR_NEGATIVE_FUNDS = "Cannot recharge account with zero or negative funds!";


        // LOAN MESSAGES
        public const string SUCCESSFULLY_DRAWN_LOAN_MESSAGE =   "Successfully drawn a {0:C} loan \n" +
                                                                "The client must return {1:C} to the bank after {2} years";

        public const string LOAN_DOES_NOT_EXIST_MESSAGE = "Such loan doesn't exist!";

        public const string ACCOUNT_BALANCE_LOWER_THAN_LOAN_RETURN_AMOUNT_MESSAGE =
                        "Account balance is less than the loan return ammount! Transaction canceled!";

        public const string SUCCESSFULLY_RETURNED_LOAN_MESSAGE = "Successfully returned the loan. \n" +
                                                                "The client returned total of {0:C} to the bank after {1} years!";

        // INVALID ARGUMENT/S MESSAGES
        public const string NEGATIVE_BALANCE_MESSAGE = "An account cannot have negative balance!";

        public const string INVALID_MONEY_AMOUNT_FORMAT_MESSAGE = "Invalid money amount format!";

        public const string TOO_MANY_ARGUMENTS_PASSED_MESSAGE = "Too many arguments passed!";

        public const string MONEY_AMOUNT_AND_YEARS_TO_RETURN_CANNOT_BE_NEGATIVE_OR_ZERO_MESSAGE =
                                "Money ammount and years to return cannot be negative!";

        public const string YEARS_TO_RETURN_MUST_BE_POSITIVE = "Years to return must be positive!";

        public const string INVALID_MONEY_AMOUNT_AND_YEARS_TO_RETURN_FORMAT_MESSAGE = "Invalid money amount and years to return format!";

        public const string INVALID_YEARS_TO_RETURN_FORMAT_MESSAGE = "Invalid years to return format!";


        // SYSTEM MESSAGES
        public const string INVALID_COMMAND_MESSAGE = "Invalid command! \n";

        public const string SUCCESSFULLY_UNDID_LAST_COMMAND_MESSAGE = "Successfully undid last command \n";

        public const string NOTHING_TO_UNDO_MESSAGE = "Nothing to undo! \n";

        public const string SHUTDOWN_MESSAGE = "Shutting down...";
    }
}
