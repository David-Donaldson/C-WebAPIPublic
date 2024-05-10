using PortfolioNoIdentityAPI.DTO;

namespace PortfolioNoIdentityAPI.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string templateName, ContactFormDTO contactFormDTO, string sentFromDomain);
        Task<bool> SendEmail(string templateName, TroubleshootingCustomerIssueDTO customerIssueDTO, string sentFromDomain, string ticketnumber);
        bool ValidateEmail(string emailAddress);
    }
}
