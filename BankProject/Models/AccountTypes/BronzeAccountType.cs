namespace BankProject.Models.AccountTypes
{
    using BankProject.Constants;
    using BankProject.Models.Interfaces;

    public class BronzeAccountType : AccountType
    {
        public BronzeAccountType(AccountType accountType)
            : this(accountType.Account)
        {
        }

        public BronzeAccountType(IAccount account) 
            : base(account)
        {
            Account = account;
            LowerLimit = AccountTypeConstant.BRONZE_ACCOUNT_TYPE_LOWER_LIMIT;
            UpperLimit = AccountTypeConstant.BRONZE_ACCOUNT_TYPE_UPPER_LIMIT;
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
                Account.AccountType = new RegularAccountType(this);
                Account.AccountType.StateChangeCheck();
            }
            else if (Account.Balance > UpperLimit)
            {
                Account.AccountType = new GoldAccountType(this);
                Account.AccountType.StateChangeCheck();
            }
        }

        public override string ToString() => AccountTypeConstant.BRONZE_ACCOUNT_TYPE_NAME;
    }
}
