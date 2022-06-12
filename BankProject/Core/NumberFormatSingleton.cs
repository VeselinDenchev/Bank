using System.Globalization;

namespace BankProject.Core
{
    internal class NumberFormatSingleton
    {
        private static readonly Lazy<NumberFormatSingleton> lazyInitialization =
                                new Lazy<NumberFormatSingleton>(() => new NumberFormatSingleton());

        private NumberFormatSingleton()
        {
            
        }

        public static NumberFormatInfo NumberFormat = new CultureInfo("en-US").NumberFormat;

        public static NumberFormatSingleton Instance => lazyInitialization.Value;
    }
}
