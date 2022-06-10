namespace EvilBank.Models
{
    using System;

    public class Client
    {
        public Client(string firstName, string lastName)
        {
            this.Id = Guid.NewGuid().ToString();
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
