
using Flunt.Validations;
using PaymentContext.Domain.Entities.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities{

    public class Student : Entity {

        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
            
        }

        public Name Name { get; set; }
        public Document Document { get; set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get {return _subscriptions.ToArray();}}
        
        public void AddSubscription(Subscription subscripton){
           
           var hasSubscriptionActive = false;
           foreach (var sub in _subscriptions)
           {
                if (sub.Active)
                    hasSubscriptionActive = true;
           }

          AddNotifications(new Contract<Student>()
          .Requires()
          .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa.")
          .AreNotEquals(0, subscripton.Payments.Count, "Student.Subscription.Payments", "Essa assinatura não possui pagamentos."));

            if(IsValid)
            _subscriptions.Add(subscripton);
           /* if (hasSubscriptionActive)  Alternativa!!
           AddNotification("Student.Subscriptions", "Você já tem uma assinatura ativa."); */

        } 
       
    }

}