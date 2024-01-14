using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryProduct : RepositoryGenerics<Product>, IProduct
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositoryProduct()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Product>> ListProducts(Expression<Func<Product, bool>> expression, int pageIndex, int pageSize)
        {
            using (var contextBase = new ContextBase(_OptionsBuilder))
            {
                if (pageIndex == 0 || pageSize == 0)
                    return await contextBase.Products.Where(expression).AsNoTracking().ToListAsync();
                else
                    return await contextBase.Products.Where(expression)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .AsNoTracking()
                        .ToListAsync();
            }
        }
    }
}
