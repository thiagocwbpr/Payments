using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Entities.ValueObjects;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests;

[TestClass]
public class SubscriptionHandlerTests
{
    [TestMethod]

    // Amadurecer em testes - metologia - Red, green, Refactor
    
    public void shouldReturnErrorWhenNameDocumentExists()
    {
        // Assert.Fail(); Aqui iremos forçar a falha acontecer, que seria o RED. Para todos os métodos.
        
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        command.BarCode = "123456789";
    }
}