using System.ComponentModel.DataAnnotations;

namespace PortfolioNoIdentityAPI.DTO
{
    public class TroubleshootingCustomerIssueDTO
    {

        public string AccountNo { get; set; }

        public string CustomerName { get; set; }

        public string ContactNumber { get; set; }

        public string EmailAddress { get; set; }

        public string AdditionalInfo { get; set; }

        public string IssueSelected { get; set; }

        public int TroubleshootingServicesId { get; set; }

    }
}
