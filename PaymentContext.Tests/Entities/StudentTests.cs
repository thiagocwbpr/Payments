using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Entities.ValueObjects;

namespace PaymentContext.Tests
{

[TestClass]
public class StudentTests
{
    private readonly Name _name;
    private readonly Document _document;
    private readonly Email _email;
    private readonly Address _address;
    private readonly Student _student;

    public StudentTests()
    {
        _name = new Name("Bruce", "Wayne");
        _document = new Document("04856525402", EDocumentType.CPF);
        _email = new Email("thiagocwbpr@gmail.com");
        _address = new Address("Rua 1", "1234", "Bairro Centro", "Curitiba", "PR", "BR", "80010050" );
        _student = new Student(_name, _document, _email);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiceSubscription()
    {
    var subscription = new Subscription(null);
     var payment = new PayPalPayment("1215458574",DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Wayne Corpo", _document, _address, _email);   
        subscription.AddPayment(payment);
        _student.AddSubscription(subscription);
        _student.AddSubscription(subscription); // Adicionando suas subscriptions para criar a falha.

        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
        var subscription = new Subscription(null);
        _student.AddSubscription(subscription); // Adicionando uma subscription quando não tiver um pagamento.

        Assert.IsTrue(!_student.IsValid); // vai falhar, pois não foi feito o pagamento.
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAddSubscription()
    {
        var subscription = new Subscription(null);
        var payment = new PayPalPayment("11111",DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP",_document, _address, _email);
        subscription.AddPayment(payment);
        _student.AddSubscription(subscription);
        Assert.IsTrue(!_student.IsValid);
    }
  }
}