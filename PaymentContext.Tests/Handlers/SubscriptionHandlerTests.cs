using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Entities.ValueObjects;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests;

// [TestClass]
public class SubscriptionHandlerTests
{
    [TestMethod]

    // Amadurecer em testes - metologia - Red, green, Refactor
    
    public void shouldReturnErrorWhenNameDocumentExists()
    {
        // Assert.Fail(); Aqui iremos forçar a falha acontecer, que seria o RED. Para todos os métodos.
        
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
                command.FirstName = "Thiago";
                command.LastName = "Menezes";
                command.Document = "999999999999";
                command.Email = "thiagocwbpr@gmail.com";
                command.BarCode = "123456789";
                command.BoletoNumber = "1234567897";
                command.PaymentNumber= "212454"; // numero interno de controle. 8 digitos.
                command.PaidDate = DateTime.Now;
                command.ExpireDate = DateTime.Now.AddMonths(1);
                command.Total = 60;
                command.TotalPaid = 60;
                command.Payer = "WAYNE CORP";
                command.PayerDocument = "12345678911";
                command.PayerDocumentType = EDocumentType.CPF;
                command.PayerEmail= "manoleiro@gmail.com"; 
                command.Street = "Rio Nilo";
                command.Number= "98"; 
                command.Neighborhood = "Rio";
                command.City = "Rio de Janeiro";
                command.State = "Rio de Janeiro";
                command.Country = "Brasil";
                command.ZipCode = "55";

                handler.Handle(command);
                Assert.AreEqual(false, handler.IsValid);
            }
}