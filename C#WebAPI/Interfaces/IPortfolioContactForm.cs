using PortfolioNoIdentityAPI.Models;

namespace PortfolioNoIdentityAPI.Interfaces
{
    public interface IPortfolioContactForm
    {
        Task <ICollection<PortfolioContact>> GetPortfolioContacts();

        bool PortfolioContactExists(int id);

        PortfolioContact GetPortfolioContact(int id);

        Task<bool> CreatePortfolioContactForm(PortfolioContact portfolioContact);

        bool UpdatePortfolioContactForm(PortfolioContact portfolioContact);

        bool DeletePortfolioContactForm(PortfolioContact portfolioContact);

        bool DeleteMultiplePortfolioContactForm( IEnumerable<PortfolioContact> portfolioContacts);

        bool Save();
    }
}
