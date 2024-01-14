using Domain.Interfaces.Generics;
using Entities.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface ISponsor : IGeneric<Sponsor>
    {
        Task<List<Sponsor>> ListSponsors(Expression<Func<Sponsor, bool>> expression);
    }
}
