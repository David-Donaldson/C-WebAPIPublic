using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioNoIdentityAPI.Models
{
    public class TroubleshootingCustomerIssue
    {
        [Key]
        public int Id { get; set; }

        public string AccountNo { get; set; }

        public string CustomerName { get; set; }

        public string ContactNumber { get; set; }

        [StringLength(100)]
        public string EmailAddress { get; set; }

        [StringLength(256)]
        public string AdditionalInfo { get; set; }

        public bool EmailSent { get; set; }

        public string TicketID { get; set; }

        [StringLength(256)]
        public string IssueSelected { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateInsertedTimestamp { get; set; }

        //navigation properties
        //public TroubleshootingServiceType TroubleshootingServiceTypes { get; set; }

        public int TroubleshootingServicesId { get; set; }
        public TroubleshootingService TroubleshootingServices { get; set; }
    }
}
