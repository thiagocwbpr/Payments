using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Entities.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class CreateBoletoSubscriptionCommandTests
{
    [TestMethod]

    // Amadurecer em testes - metologia - Red, green, Refactor
    
    public void shouldReturnErrorWhenNameIsInvalid()
    {
        // Assert.Fail(); Aqui iremos forçar a falha acontecer, que seria o RED. Para todos os métodos.
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "";

        command.Validate();
        Assert.AreEqual(false,command.IsValid);
    }
}