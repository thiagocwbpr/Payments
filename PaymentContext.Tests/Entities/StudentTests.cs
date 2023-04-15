using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests;

[TestClass]
public class UnitTest
{
    [TestMethod]
    public void TestMethod()
    {
        var subscription = new Subscription();
        var student = new Student("Thiago","Menezes","2081780588","thiagocwbpr@gmail.com");
        
        student.AddSubscription(subscription);
        
    }
}