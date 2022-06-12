namespace BankProject.Singletons
{
    using System.Globalization;

    internal sealed class NumberFormatSingleton : ISingleton<NumberFormatInfo>
    {
        private static readonly Lazy<NumberFormatInfo> lazyInitialization =
                                new Lazy<NumberFormatInfo>(() => new CultureInfo("en-US").NumberFormat);

        private NumberFormatSingleton()
        {
            
        }

        public static NumberFormatInfo Instance => lazyInitialization.Value;
    }
}
