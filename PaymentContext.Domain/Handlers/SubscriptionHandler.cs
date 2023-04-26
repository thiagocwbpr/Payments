

using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Entities.ValueObjects;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable<Notification>, 
    IHandler<CreateBoletoSubscriptionCommand>,
    IHandler<CreatePayPalSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if(!command.IsValid){
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar seu cadastro.");
            }
            // Verificar se documento já está cadastrado.
            if(_repository.DocumentExists(command.Document))
            AddNotification("Document", "Esse CPF já está cadastrado.");
            
            // { <-- Você pode fazer esse tipo de notificação também.
            //  AddNotifications(command);
            //  return new CommandResult(false, "CPF já em uso. ");  
            // }

            // Verificar se email já está cadastrado.
            if(_repository.EmailExists(command.Email))
            AddNotification("Email", "Esse E-mail já está cadastrado.");
            
            // { <-- O mesmo para esse, pode ser utilizado.
            //  AddNotifications(command);
            //  return new CommandResult(false, "Não foi possível realizar sua assinatura");  
            // }
            

            // Gerar os VOs
           var name = new Name(command.FirstName, command.LastName);
           var document = new Document(command.Document, EDocumentType.CPF);
           var email = new Email(command.Email);
           var address = new Address(
           command.Street,
           command.Number,
           command.Neighborhood,
           command.City,
           command.State,
           command.Country,
           command.ZipCode);
           

            // Gerar as entidades
            var student = new Student(name,document,email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(
            command.BarCode, 
            command.BoletoNumber, 
            command.PaidDate, 
            command.ExpireDate,
            command.Total,
            command.TotalPaid, 
            command.Payer,new Document(
            command.Document, 
            command.PayerDocumentType), address, email);

            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Aplicar as validações
            AddNotifications(name, document,email, address, student,subscription,payment);

            // Salvar as informações
            _repository.CreateSubscription(student);

            // Enviar email de boas vindas.
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem Vindo ao nosso portal", "Sua assinatura foi criada.");

            // Retornar informações

            return new CommandResult(true, "Assinatura realizada com sucesso.");
        }

        // Handler de PayPal
        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            // Fail Fast Validations
            
            // Verificar se documento já está cadastrado.
            if(_repository.DocumentExists(command.Document))
            AddNotification("Document", "Esse CPF já está cadastrado.");
            
            // { <-- Você pode fazer esse tipo de notificação também.
            //  AddNotifications(command);
            //  return new CommandResult(false, "CPF já em uso. ");  
            // }

            // Verificar se email já está cadastrado.
            if(_repository.EmailExists(command.Email))
            AddNotification("Email", "Esse E-mail já está cadastrado.");
            
            // { <-- O mesmo para esse, pode ser utilizado.
            //  AddNotifications(command);
            //  return new CommandResult(false, "Não foi possível realizar sua assinatura");  
            // }
            

            // Gerar os VOs
           var name = new Name(command.FirstName, command.LastName);
           var document = new Document(command.Document, EDocumentType.CPF);
           var email = new Email(command.Email);
           var address = new Address(
           command.Street,
           command.Number,
           command.Neighborhood,
           command.City,
           command.State,
           command.Country,
           command.ZipCode);
           

            // Gerar as entidades
            var student = new Student(name,document,email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            // Somente muda a implementação do pagamento, abaixo:
            var payment = new PayPalPayment(
            command.TransactionCode,
            command.PaidDate, 
            command.ExpireDate,
            command.Total,
            command.TotalPaid, 
            command.Payer,new Document(
            command.Document, 
            command.PayerDocumentType), address, email);

            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Aplicar as validações
            AddNotifications(name, document,email, address, student,subscription,payment);

            // Salvar as informações
            _repository.CreateSubscription(student);

            // Enviar email de boas vindas.
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem Vindo ao nosso portal", "Sua assinatura foi criada.");

            // Retornar informações

            return new CommandResult(true, "Assinatura realizada com sucesso.");
        }
    }
}