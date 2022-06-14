namespace BankProject.Models.AccountTypes
{
    using BankProject.Constants;
    using BankProject.Models.Interfaces;

    public class Gold : AccountType
    {
        public Gold(AccountType accountType)
            : this(accountType.Account)
        {
        }

        public Gold(IAccount account) 
            : base(account)
        {
            Account = account;
            LowerLimit = AccountTypeLimitConstant.GOLD_ACCOUNT_TYPE_LOWER_LIMIT;
            UpperLimit = AccountTypeLimitConstant.GOLD_ACCOUNT_TYPE_UPPER_LIMIT;
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
                Account.AccountType = new Bronze(this);
                Account.AccountType.StateChangeCheck();
            }
            else if (Account.Balance > UpperLimit)
            {
                Account.AccountType = new Platinum(this);
                Account.AccountType.StateChangeCheck();
            }
        }
    }
}
