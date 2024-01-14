using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/sponsor/[controller]")]
    [ApiController]
    public class SponsorController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly ISponsor _ISponsor;
        private readonly IServiceSponsor _IServiceSponsor;

        public SponsorController(IMapper iMapper, ISponsor iSponsor, IServiceSponsor iServiceSponsor)
        {
            _IMapper = iMapper;
            _ISponsor = iSponsor;
            _IServiceSponsor = iServiceSponsor;
        }

        private async Task<string> GetLoggedUserId()
        {
            if (User != null)
            {
                var idUser = User.FindFirst("idUser");

                if (idUser != null)
                    return idUser.Value;
            }

            return string.Empty;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/sponsor/Add")]
        public async Task<List<Notifies>> Add(SponsorViewModel sponsor)
        {
            sponsor.UserId = await GetLoggedUserId();
            var sponsorMap = _IMapper.Map<Sponsor>(sponsor);
            await _IServiceSponsor.Add(sponsorMap);
            return sponsorMap.Notifications;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/sponsor/Update")]
        public async Task<List<Notifies>> Update(SponsorViewModel sponsor)
        {
            sponsor.UserId = await GetLoggedUserId();
            var sponsorMap = _IMapper.Map<Sponsor>(sponsor);
            await _IServiceSponsor.Update(sponsorMap);
            return sponsorMap.Notifications;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/sponsor/Delete")]
        public async Task<List<Notifies>> Delete(SponsorViewModel sponsor)
        {
            sponsor.UserId = await GetLoggedUserId();
            var sponsorMap = _IMapper.Map<Sponsor>(sponsor);
            await _IServiceSponsor.Delete(sponsorMap);
            return sponsorMap.Notifications;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/sponsor/GetEntityById")]
        public async Task<SponsorViewModel> GetEntityById(SponsorViewModel sponsor)
        {
            var ret = await _ISponsor.GetEntityById(sponsor.Id);
            var sponsorMap = _IMapper.Map<SponsorViewModel>(ret);
            return sponsorMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/sponsor/List")]
        public async Task<List<SponsorViewModel>> List()
        {
            var sponsors = await _ISponsor.List();
            var sponsorMap = _IMapper.Map<List<SponsorViewModel>>(sponsors);
            return sponsorMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/sponsor/ListActivesSponsors")]
        public async Task<List<SponsorViewModel>> ListActivesSponsors()
        {
            var sponsors = await _IServiceSponsor.ListActivesSponsors();
            var sponsorMap = _IMapper.Map<List<SponsorViewModel>>(sponsors);
            return sponsorMap;
        }

    }
}
