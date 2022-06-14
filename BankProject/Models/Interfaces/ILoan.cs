namespace BankProject.Models.Interfaces
{
    public interface ILoan : IIdentity<string>
    {
        public decimal DrawnAmount { get; init; }

        public decimal InterestRate { get; init; }

        public byte YearsToReturn { get; init; }

        public decimal AmountToReturn => DrawnAmount * (1 + YearsToReturn * InterestRate); // Simple interest rate
    }
}
