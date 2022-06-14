namespace BankProject.Constants
{
    public static class StringConstant
    {
        // CULTURES
        public const string ENGLISH_UNITED_STATES_CULTURE_STRING = "en-US";


        // LOAN
        public const string LOAN_STRING =   "\tID: {0} \n" +
                                            "\tDrawn ammount: {1:C} \n" +
                                            "\tInterest rate: {2}% \n" +
                                            "\tYears to return: {3} \n" +
                                            "\tAmount to return: {4:C}";

        public const string LOANS_TO_BE_RETURNED_STRING = "Loans to be returned:";

        public const string LOAN_SEPERATOR = "\t---------------------------------------------------------------------------------";


        // CHECK
        public const string BALANCE_CHECK_STRING = "Balance";

        public const string ACCOUNT_TYPE_CHECK_STRING = "AccountType";

        public const string ACCOUNT_CHECK_STRING = "Account";


        // ACCOUNT
        public const string ACCOUNT_STRING =    "Fullname: {0} \n" +
                                                "ID: {1} \n" +
                                                "Balance: {2:C} \n" +
                                                "Account type: {3}";
    }
}