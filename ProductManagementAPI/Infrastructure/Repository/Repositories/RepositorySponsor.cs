using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    public class RepositorySponsor : RepositoryGenerics<Sponsor>, ISponsor
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositorySponsor()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Sponsor>> ListSponsors(Expression<Func<Sponsor, bool>> expression)
        {
            using (var contextBase = new ContextBase(_OptionsBuilder))
            {
                return await contextBase.Sponsors.Where(expression).AsNoTracking().ToListAsync();
            }
        }
    }
}
