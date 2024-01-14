using Entities.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceSponsor
    {
        Task Add(Sponsor sponsor);
        Task Update(Sponsor sponsor);
        Task Delete(Sponsor sponsor);
        Task<List<Sponsor>> ListActivesSponsors();
    }
}
