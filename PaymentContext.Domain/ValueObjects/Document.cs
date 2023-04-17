using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract<Document>().Requires().IsTrue(Validate(), "Document.Number","Documento inválido."));
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        private bool Validate(){ 
            
                if(Type == EDocumentType.CPNJ && Number.Length == 14)
                    return true;

                if(Type == EDocumentType.CPF && Number.Length == 11)
                    return true;

                return false;
            }
    }
}