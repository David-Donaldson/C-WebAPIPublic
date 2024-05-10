using PortfolioNoIdentityAPI.Data;
using PortfolioNoIdentityAPI.Interfaces;
using PortfolioNoIdentityAPI.Models;

namespace PortfolioNoIdentityAPI.Repositories
{
    public class TroubleshootingServiceRepository: ITroubleshootingService
    {
        private readonly DataContext _context;

        public TroubleshootingServiceRepository(DataContext context)
        {
            _context = context;            
        }

        public ICollection<TroubleshootingService> GetTroubleshootingServices()
        {
            return _context.TroubleshootingServices.ToList();
        }

        public TroubleshootingService GetTroubleshootingService(int id)
        {
            return _context.TroubleshootingServices.Where(x => x.Id == id).FirstOrDefault();
        }
    
        public bool TroubleshootingServiceExists(string name)
        {
            return _context.TroubleshootingServices.Any(x => x.ServiceName == name);
        }

        public bool CreateTroubleshootingService(TroubleshootingService troubleshootingService) {
            _context.Add(troubleshootingService);
            return Save();
        }

        public bool DeleteTroubleshootingService(TroubleshootingService service)
        {
            _context.Remove(service);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0? true : false;
        }
    }
}
