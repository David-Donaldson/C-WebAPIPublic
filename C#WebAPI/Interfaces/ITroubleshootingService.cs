using PortfolioNoIdentityAPI.Models;

namespace PortfolioNoIdentityAPI.Interfaces
{
    public interface ITroubleshootingService
    {
        ICollection<TroubleshootingService> GetTroubleshootingServices();

        TroubleshootingService GetTroubleshootingService(int id);

        bool TroubleshootingServiceExists(string name);

        bool CreateTroubleshootingService(TroubleshootingService service);

        bool DeleteTroubleshootingService(TroubleshootingService service);

        bool Save();
    }
}
