

using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities.ValueObjects
{
    public class Email : ValueObject 
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract<Email>().Requires().IsEmail(Address, "Email.Address", "Email inválido"));
        }

        public string Address { get; private set; }
    }
}