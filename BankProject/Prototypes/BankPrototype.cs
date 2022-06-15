namespace BankProject.Prototypes
{
    using System.Collections.Generic;

    using BankProject.Mementos;
    using BankProject.Mementos.Interfaces;
    using BankProject.Models;
    using BankProject.Models.Interfaces;
    using BankProject.Prototypes.Interfaces;

    public abstract class BankPrototype : IPrototype<BankPrototype>
    {
        public BankPrototype()
        {
            this.Accounts = new List<IAccount>();
            this.MementosStack = new Caretaker<Bank>().MementosStack;
        }

        public List<IAccount> Accounts { get; set; }

        public Stack<IMemento<Bank>> MementosStack { get; set; }

        public Bank State { get; set; }

        public abstract BankPrototype Clone();
    }
}
