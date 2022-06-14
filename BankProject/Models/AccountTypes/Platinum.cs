namespace BankProject.Models.AccountTypes
{
    using BankProject.Constants;
    using BankProject.Models.Interfaces;

    public class Platinum : AccountType
    {
        public Platinum(AccountType accountType)
            : this(accountType.Account)
        {
        }

        public Platinum(IAccount account) 
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
                Account.AccountType = new Gold(this);
                Account.AccountType.StateChangeCheck();
            }
        }
    }
}
