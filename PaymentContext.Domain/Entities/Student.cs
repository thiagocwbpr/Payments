namespace PaymentContext.Domain.Entities{

    public class Student{

        private IList<Subscription> _subscriptions;
        public Student(string firstName, string lastName, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            if(firstName.Length == 0)
            throw new Exception("Nome inválido."); // Forma de validação.
            
        }

        public string FirstName { get; private set; }    
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get {return _subscriptions.ToArray();}}
        
        public void AddSubscription(Subscription subscripton){
            foreach (var sub in _subscriptions){
                sub.Active = false;
            }
            _subscriptions.Add(subscripton);
        }
    }

}