namespace BankProject.Models.AccountTypes
{
    using BankProject.Constants;
    using BankProject.Models.Interfaces;

    public class RegularAccountType : AccountType
    {
        public RegularAccountType(AccountType accountType)
            : this(accountType.Account)
        {
        }

        public RegularAccountType(IAccount account) 
            : base(account)
        {
            Account = account;
            LowerLimit = AccountTypeConstant.REGULAR_ACCOUNT_TYPE_LOWER_LIMIT;
            UpperLimit = AccountTypeConstant.REGULAR_ACCOUNT_TYPE_UPPER_LIMIT;
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
            if (Account.Balance > UpperLimit)
            {
                Account.AccountType = new BronzeAccountType(this);
                Account.AccountType.StateChangeCheck();
            }
        }

        public override string ToString() => AccountTypeConstant.REGULAR_ACCOUNT_TYPE_NAME;
    }
}
