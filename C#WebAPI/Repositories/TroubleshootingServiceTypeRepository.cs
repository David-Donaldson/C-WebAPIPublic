using Microsoft.EntityFrameworkCore;
using PortfolioNoIdentityAPI.Data;
using PortfolioNoIdentityAPI.Interfaces;
using PortfolioNoIdentityAPI.Models;

namespace PortfolioNoIdentityAPI.Repositories
{
    public class TroubleshootingServiceTypeRepository: ITroubleshootingServiceType
    {
        private readonly DataContext _context;

        public TroubleshootingServiceTypeRepository(DataContext context)
        {
            _context = context;            
        }

        public async Task<IEnumerable<object>> GetTroubleshootingServiceTypes()
        {
            var query = from serviceType 
                        in _context.TroubleshootingServiceTypes 
                        join 
                            service in _context.TroubleshootingServices 
                                on serviceType.ServiceId 
                                equals service.Id 
                                select new { 
                                            Servicename = service.ServiceName, 
                                            service.Id, 
                                            serviceType.ServiceTypeDescription };

            return await query.ToListAsync<object>();
        }

        public TroubleshootingServiceType GetTroubleshootingServiceType(int id)
        {
            return _context.TroubleshootingServiceTypes.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool CreateTroubleshootingServiceType(TroubleshootingServiceType serviceType)
        {
            _context.Add(serviceType);
            return Save();
        }

        public bool DeleteTroubleshootingServiceType(TroubleshootingServiceType serviceTypeToRemove)
        {
            _context.Remove(serviceTypeToRemove);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
