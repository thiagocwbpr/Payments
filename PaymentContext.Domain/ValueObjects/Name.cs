using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if(string.IsNullOrEmpty(FirstName))
            AddNotification("Name.FirstName", "Nome Inválido.");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}