using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioNoIdentityAPI.Models
{
    public class PortfolioContact
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string ContactName { get; set; }

        public string EmailAddress { get; set; }

        [StringLength(256)]
        public string EmailMessage { get; set; }

        public bool EmailSent { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateInsertedTimestamp { get; set; }

    }
}
