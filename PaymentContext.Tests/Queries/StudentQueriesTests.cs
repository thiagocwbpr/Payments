using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Entities.ValueObjects;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Queries;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests;

[TestClass]
public class StudentQueriesTests
{
    private IList<Student> _students;

    public StudentQueriesTests()
    {
        for (int i = 0; i <= 10; i++)
        {
            _students.Add(new Student(
            new Name("Aluno", i.ToString()),
            new Document("1111111111" + i.ToString(), EDocumentType.CPF),
            new Email(i.ToString() + "@gmail.com")));
        }
    }

    [TestMethod]

    // Amadurecer em testes - metologia - Red, green, Refactor
    
    public void shouldReturnNullWhenDocumentNotExists()
    {
        // Assert.Fail(); Aqui iremos forçar a falha acontecer, que seria o RED. Para todos os métodos.
        
        var exp = StudentQueries.GetStudentInfo("12345678911");
        var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreNotEqual(null,studn);
    }

    public void shouldReturnStudentWhenDocumentExists()
    {
        // Assert.Fail(); Aqui iremos forçar a falha acontecer, que seria o RED. Para todos os métodos.
        
        var exp = StudentQueries.GetStudentInfo("1111111111");
        var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreNotEqual(null,studn);
    }
}