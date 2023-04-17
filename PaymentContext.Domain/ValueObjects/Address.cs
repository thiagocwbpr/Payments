
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract<Address>().Requires().IsGreaterOrEqualsThan(street, 3, "O endereço deve conter ao menos 3 caracteres."));
            AddNotifications(new Contract<Address>().Requires().IsGreaterOrEqualsThan(number, 1, "O numero deve conter no minimo 1 caractere."));
            AddNotifications(new Contract<Address>().Requires().IsGreaterOrEqualsThan(neighborhood, 3, "O bairro deve conter ao menos 3 caracteres."));
            AddNotifications(new Contract<Address>().Requires().IsGreaterOrEqualsThan(city, 3, "A cidade deve conter ao menos 3 caracteres."));
            AddNotifications(new Contract<Address>().Requires().IsGreaterOrEqualsThan(state, 3, "O estado deve conter ao menos 3 caracteres."));
            AddNotifications(new Contract<Address>().Requires().IsGreaterOrEqualsThan(country, 3, "O País deve conter ao menos 3 caracteres."));
            AddNotifications(new Contract<Address>().Requires().IsGreaterOrEqualsThan(zipCode, 3, "O CEP deve conter ao menos 3 caracteres."));
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}