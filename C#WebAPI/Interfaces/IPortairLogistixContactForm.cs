using PortfolioNoIdentityAPI.Models;

namespace PortfolioNoIdentityAPI.Interfaces
{
    public interface IPortairLogistixContactForm
    {
        Task<ICollection<PortairLogistixContact>> GetPortairLogistixContacts();

        Task<PortairLogistixContact> GetPortairLogistixContact(int id);

        bool PortairLogistixContactExists(int id);

        Task<bool> CreatePortAirLogistixForm(PortairLogistixContact portairLogistixContact);

        bool UpdatePortairLogistixForm(PortairLogistixContact portairLogistixContact);

        bool DeletePortairLogistixForm(PortairLogistixContact portairLogistixContact);

        bool Save();
    }
}
