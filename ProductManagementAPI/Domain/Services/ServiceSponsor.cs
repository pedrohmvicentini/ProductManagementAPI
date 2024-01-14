using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;

namespace Domain.Services
{
    public class ServiceSponsor : IServiceSponsor
    {
        private readonly ISponsor _ISponsor;

        public ServiceSponsor(ISponsor iSponsor)
        {
            _ISponsor = iSponsor;
        }

        public async Task Add(Sponsor sponsor)
        {
            var isValid = sponsor.ValidateStringValue(sponsor.Description, "Description");
            if (isValid)
            {
                sponsor.CreatedAt = DateTime.Now;
                sponsor.UpdatedAt = DateTime.Now;
                sponsor.Active = true;
                await _ISponsor.Add(sponsor);
            }
        }

        public async Task Update(Sponsor sponsor)
        {
            var isValid = sponsor.ValidateStringValue(sponsor.Description, "Description");
            if (isValid)
            {
                sponsor.UpdatedAt = DateTime.Now;
                await _ISponsor.Update(sponsor);
            }
        }

        public async Task Delete(Sponsor sponsor)
        {
            if (sponsor!= null && sponsor.Id > 0)
            {
                Sponsor data = await _ISponsor.GetEntityById(sponsor.Id);

                if (data != null)
                {
                    data.Active = false;
                    data.DeletedAt = DateTime.Now;
                    await _ISponsor.Update(data);
                }
            }
        }

        public async Task<List<Sponsor>> ListActivesSponsors()
        {
            return await _ISponsor.ListSponsors(n => n.Active);
        }
    }
}
