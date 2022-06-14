namespace BankProject.Models.AccountTypes
{
    using BankProject.Constants;
    using BankProject.Models.Interfaces;

    public class PlatinumAccountType : AccountType
    {
        public PlatinumAccountType(AccountType accountType)
            : this(accountType.Account)
        {
        }

        public PlatinumAccountType(IAccount account) 
            : base(account)
        {
            Account = account;
            LowerLimit = AccountTypeLimitConstant.PLATINUM_ACCOUNT_TYPE_LOWER_LIMIT;
            UpperLimit = AccountTypeLimitConstant.PLATINUM_ACCOUNT_TYPE_UPPER_LIMIT;
        }

        public override void AddMoneyToAccount(decimal amount)
        {
            base.AddMoneyToAccount(amount);
            StateChangeCheck();
        }

        public override void DrawMoneyFromAccount(decimal amount)
        {
            base.DrawMoneyFromAccount(amount);
            StateChangeCheck();
        }

        public override void StateChangeCheck()
        {
            if (Account.Balance < LowerLimit)
            {
                Account.AccountType = new GoldAccountType(this);
                Account.AccountType.StateChangeCheck();
            }
        }
    }
}
