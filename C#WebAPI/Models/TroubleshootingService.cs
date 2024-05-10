using System.ComponentModel.DataAnnotations;

namespace PortfolioNoIdentityAPI.Models
{
    public class TroubleshootingService
    {
        [Key]
        public int Id { get; set; }

        public string ServiceName { get; set; }

        //navigation properties
        public TroubleshootingServiceType TroubleshootingServiceTypes { get; set; }
        public ICollection<TroubleshootingCustomerIssue> TroubleshootingCustomerIssues { get; set; }    
    }
}
