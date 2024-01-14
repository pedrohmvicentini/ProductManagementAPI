using Domain.Interfaces.Generics;
using Entities.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IProduct : IGeneric<Product>
    {
        Task<List<Product>> ListProducts(Expression<Func<Product, bool>> expression);
    }
}
