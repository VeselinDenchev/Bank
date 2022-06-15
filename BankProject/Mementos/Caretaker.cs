namespace BankProject.Mementos
{
    using BankProject.Mementos.Interfaces;

    public class Caretaker<T>
    {
        public Caretaker()
        {
            this.MementosStack = new Stack<IMemento<T>>();
        }

        public Stack<IMemento<T>> MementosStack { get; set; }
    }
}
