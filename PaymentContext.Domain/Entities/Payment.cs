namespace PaymentContext.Domain.Entities
{
    public abstract class Payment{
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string owner, string document, string address, string email)
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper(); // criando um Guid, utilizando o ToString para ser string, usando Replace para substituir os traços, o substring para trazer 10 caracteres e o ToUpper para trazer tudo maiusculo.
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Owner = owner;
            Document = document;
            Address = address;
            Email = email;
        }
        public string Number { get; private set; } // numero interno de controle. 8 digitos.
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Owner { get; private set; }
        public string Document { get; private set; }
        public string Address { get; private set; }
        public string Email { get; private set; }
    }


    
}