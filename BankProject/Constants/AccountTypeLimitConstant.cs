namespace BankProject.Constants
{
    public static class AccountTypeLimitConstant
    {
        public const decimal REGULAR_ACCOUNT_TYPE_LOWER_LIMIT = 0;

        public const decimal REGULAR_ACCOUNT_TYPE_UPPER_LIMIT = 100_000;

        public const decimal BRONZE_ACCOUNT_TYPE_LOWER_LIMIT = REGULAR_ACCOUNT_TYPE_UPPER_LIMIT;

        public const decimal BRONZE_ACCOUNT_TYPE_UPPER_LIMIT = 200_000;

        public const decimal GOLD_ACCOUNT_TYPE_LOWER_LIMIT = BRONZE_ACCOUNT_TYPE_UPPER_LIMIT;

        public const decimal GOLD_ACCOUNT_TYPE_UPPER_LIMIT = 500_000;

        public const decimal PLATINUM_ACCOUNT_TYPE_LOWER_LIMIT = GOLD_ACCOUNT_TYPE_UPPER_LIMIT;

        public const decimal PLATINUM_ACCOUNT_TYPE_UPPER_LIMIT = decimal.MaxValue;
    }
}
