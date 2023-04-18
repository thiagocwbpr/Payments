
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Entities.ValueObjects;

namespace PaymentContext.Tests;

// [TestClass]
public class DocumentTests
{
    [TestMethod]

    // Amadurecer em testes - metologia - Red, green, Refactor
    
    public void shouldReturnErrorWhenCNPJIsInvalid()
    {
        // Assert.Fail(); Aqui iremos forçar a falha acontecer, que seria o RED. Para todos os métodos.
        var doc = new Document("123", EDocumentType.CPNJ);
        Assert.IsTrue(!doc.IsValid);
    }
    [TestMethod]
    public void shouldReturnSuccessWhenCNPJIsValid()
    {
        var doc = new Document("35478965123467", EDocumentType.CPNJ);
        Assert.IsTrue(doc.IsValid);  
    }
    [TestMethod]
    public void shouldReturnErrorWhenCPFIsInvalid()
    {
        var doc = new Document("054", EDocumentType.CPF);
        Assert.IsTrue(!doc.IsValid);
    }
    [TestMethod]
    [DataTestMethod]
    [DataRow("94789182223")] // Permite testar vários CPF de uma vez, passando um atributo string CPF no método.
    [DataRow("42835292225")]
    [DataRow("05136217413")]
    public void shouldReturnSuccessWhenCPFIsValid(string cpf)
    {
        var doc = new Document(cpf,EDocumentType.CPF);
        Assert.IsTrue(doc.IsValid); 
    }
}