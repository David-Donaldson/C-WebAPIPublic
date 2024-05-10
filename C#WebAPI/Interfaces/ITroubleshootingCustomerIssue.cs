using PortfolioNoIdentityAPI.Models;

namespace PortfolioNoIdentityAPI.Interfaces
{
    public interface ITroubleshootingCustomerIssue
    {
        Task <ICollection<TroubleshootingCustomerIssue>> GetTroubleshootingCustomerIssues();

        Task <bool> CreateCustomerIssue(TroubleshootingCustomerIssue troubleshootingCustomerIssue);

        TroubleshootingCustomerIssue GetCustomerIssue(int customerId);

        Task<bool> DuplicateTicketCheck(string TicketID);

        bool Save();
    }
}
