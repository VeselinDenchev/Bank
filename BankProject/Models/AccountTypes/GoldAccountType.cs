namespace BankProject.Models.AccountTypes
{
    using BankProject.Constants;
    using BankProject.Models.Interfaces;

    public class GoldAccountType : AccountType
    {
        public GoldAccountType(AccountType accountType)
            : this(accountType.Account)
        {
        }

        public GoldAccountType(IAccount account) 
            : base(account)
        {
            Account = account;
            LowerLimit = AccountTypeConstant.GOLD_ACCOUNT_TYPE_LOWER_LIMIT;
            UpperLimit = AccountTypeConstant.GOLD_ACCOUNT_TYPE_UPPER_LIMIT;
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
                Account.AccountType = new BronzeAccountType(this);
                Account.AccountType.StateChangeCheck();
            }
            else if (Account.Balance > UpperLimit)
            {
                Account.AccountType = new PlatinumAccountType(this);
                Account.AccountType.StateChangeCheck();
            }
        }

        public override string ToString() => AccountTypeConstant.GOLD_ACCOUNT_TYPE_NAME;
    }
}
