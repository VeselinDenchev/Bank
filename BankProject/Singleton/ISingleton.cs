namespace BankProject.Singleton
{
    internal interface ISingleton<T> 
        where T : new()
    {
        protected static Lazy<T> lazyInitialization = new Lazy<T>(() => new T());

        public static T Instance => lazyInitialization.Value;
    }
}
