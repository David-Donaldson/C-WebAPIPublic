using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioNoIdentityAPI.Models
{
    public class TroubleshootingServiceType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength]
        public string ServiceTypeDescription { get; set; }

        [ForeignKey("TroubleshootingServices")]
        public int ServiceId { get; set; }

        //navigation properties
        public TroubleshootingService TroubleshootingServices { get; set; }
        //public ICollection<TroubleshootingCustomerIssue> TroubleshootingCustomerIssues { get; set; }
    }
}
