

using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Entities.ValueObjects;
using PaymentContext.Domain.Repositories;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;

        public SubscriptionHandler(IStudentRepository repository)
        {
            _repository = repository;
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
           var address = new Address(command.Street,command.Number,command.Neighborhood,command.City,command.State,command.Country,command.ZipCode);
           var student = new Student(_name, _document, _email);

            // Gerar as entidades

            // Aplicar as validações

            // Salvar as informações

            // Enviar email de boas vindas.

            // Retornar informações

            return new CommandResult(true, "Assinatura realizada com sucesso.");
        }
    }
}