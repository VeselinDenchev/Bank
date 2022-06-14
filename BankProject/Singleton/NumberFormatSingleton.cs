namespace BankProject.Singleton
{
    using System.Globalization;

    using BankProject.Constants;

    internal sealed class NumberFormatSingleton : ISingleton<NumberFormatInfo>
    {
        private static readonly Lazy<NumberFormatInfo> lazyInitialization =
                                new Lazy<NumberFormatInfo>(() => new CultureInfo(StringConstant.ENGLISH_UNITED_STATES_CULTURE_STRING).NumberFormat);

        private NumberFormatSingleton()
        {
        }

        public static NumberFormatInfo Instance => lazyInitialization.Value;
    }
}
