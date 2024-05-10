using PortfolioNoIdentityAPI.Models;

namespace PortfolioNoIdentityAPI.Interfaces
{
    public interface ITroubleshootingServiceType
    {
        Task<IEnumerable<object>> GetTroubleshootingServiceTypes();

        TroubleshootingServiceType GetTroubleshootingServiceType(int id);

        bool CreateTroubleshootingServiceType(TroubleshootingServiceType serviceType);

        bool DeleteTroubleshootingServiceType(TroubleshootingServiceType serviceType);

        bool Save();
    }
}
