using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Entities.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class StudentTests
{
    private readonly Name _name;
    private readonly Document _document;
    private readonly Email _email;
    private readonly Address _address;
    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
        _name = new Name("Bruce", "Wayne");
        _document = new Document("04856525402", EDocumentType.CPF);
        _email = new Email("thiagocwbpr@gmail.com");
        _address = new Address("Rua 1", "1234", "Bairro Centro", "Curitiba", "PR", "BR", "80010050" );
        _student = new Student(_name, _document, _email);
        _subscription = new Subscription(null);
  
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiceSubscription()
    {
     var payment = new PayPalPayment("1215458574",DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Wayne Corpo", _document, _address, _email);   
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
      
        _student.AddSubscription(_subscription);

        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenHadNoActiceSubscription()
    {
        var payment = new PayPalPayment("1215458574",DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Wayne Corpo", _document, _address, _email);
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(_student.IsValid);
    }
}