using System.Linq.Expressions;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Queries{

    public static class StudentQueries{


        // expressão LINQ.
        // possível criar qualquer expressão sobre o banco de dados abaixo.
        public static Expression<Func<Student,bool>> GetStudent(string document){
        
            return x => x.Document.Number == document;

        }
    }
}