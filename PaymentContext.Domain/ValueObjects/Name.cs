using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Name>().Requires()
            .IsLowerOrEqualsThan(firstName, 3, "Name.FirstName", "Nome deve conter no mínimo 3 caracteres.")
            .IsLowerOrEqualsThan(lastName, 3, "Name.LastName", "Sobrenome deve conter no minimo 3 caracteres."));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}