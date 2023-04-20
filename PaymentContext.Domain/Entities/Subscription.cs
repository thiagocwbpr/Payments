using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity{

        // CONSTRUTOR
        private IList<Payment> _payments; // Esquema para trabalhar com a lista de forma interna.
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;
            Active = true;
            _payments = new List<Payment>(); // inicializando a lista interna.
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get {return _payments.ToArray();}}

        // METHOD
        public void AddPayment(Payment payment){ // Método de pagamento.

        AddNotifications(new Contract<Subscription>()
        .Requires()
        .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "A data do pagamento deve ser futura."));

        // if(IsValid) verifica se é valido.

        _payments.Add(payment);
        }
        public void Activate(){
            Active = true;
            LastUpdateDate = DateTime.Now;
        }
        public void Inactivate(){
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}