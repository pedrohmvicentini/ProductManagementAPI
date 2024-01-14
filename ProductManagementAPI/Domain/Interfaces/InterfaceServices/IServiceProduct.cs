using Entities.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceProduct
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Product product);
        Task<List<Product>> ListActivesProducts(int id, string description, int pageIndex, int pageSize);
    }
}
