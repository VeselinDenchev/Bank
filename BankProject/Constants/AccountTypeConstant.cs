namespace BankProject.Constants
{
    public static class AccountTypeConstant
    {
        // REGULAR ACCOUNT TYPE
        public const string REGULAR_ACCOUNT_TYPE_NAME = "Regular";

        public const decimal REGULAR_ACCOUNT_TYPE_LOWER_LIMIT = 0;

        public const decimal REGULAR_ACCOUNT_TYPE_UPPER_LIMIT = 100_000;


        // BRONZE ACCOUNT TYPE
        public const string BRONZE_ACCOUNT_TYPE_NAME = "Bronze";

        public const decimal BRONZE_ACCOUNT_TYPE_LOWER_LIMIT = REGULAR_ACCOUNT_TYPE_UPPER_LIMIT;

        public const decimal BRONZE_ACCOUNT_TYPE_UPPER_LIMIT = 200_000;


        // GOLD ACCOUNT TYPE
        public const string GOLD_ACCOUNT_TYPE_NAME = "Gold";

        public const decimal GOLD_ACCOUNT_TYPE_LOWER_LIMIT = BRONZE_ACCOUNT_TYPE_UPPER_LIMIT;

        public const decimal GOLD_ACCOUNT_TYPE_UPPER_LIMIT = 500_000;


        // PLATINUM ACCOUNT TYPE
        public const string PLATINUM_ACCOUNT_TYPE_NAME = "Platinum";

        public const decimal PLATINUM_ACCOUNT_TYPE_LOWER_LIMIT = GOLD_ACCOUNT_TYPE_UPPER_LIMIT;

        public const decimal PLATINUM_ACCOUNT_TYPE_UPPER_LIMIT = decimal.MaxValue;
    }
}
