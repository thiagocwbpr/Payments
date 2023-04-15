namespace PaymentContext.Domain.Entities
{
    public abstract class Payment{
        
        public string Number { get; set; } // numero interno de controle. 8 digitos.
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Owner { get; set; }
        public string Document { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

    }

     public class BoletoPayment : Payment{
        public string BarCode { get; set; }
        public string BoletoNumber { get; set; } // gerado pela entidade. 12 digitos.
    }

     public class CreditCardPayment : Payment{
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }
    }

     public class PayPalPayment : Payment{
        
        public string TransactionCode { get; set; }
    }
}