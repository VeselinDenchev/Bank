namespace BankProject.Mementos.Interfaces
{
    public interface IOriginator<T>
    {
        public T State { get; set; }

        public Memento<T> SaveMemento() => new Memento<T>(this.State);

        public void RestoreMemento(Memento<T> memento) => this.State = memento.State;
    }
}
