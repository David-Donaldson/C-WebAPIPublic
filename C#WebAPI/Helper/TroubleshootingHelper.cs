using PortfolioNoIdentityAPI.Interfaces;

namespace PortfolioNoIdentityAPI.Helper
{
    public class TroubleshootingHelper
    {
        private readonly ITroubleshootingCustomerIssue _troubleshootingCustomerIssue;
        private string ticketID = "";

        public TroubleshootingHelper(ITroubleshootingCustomerIssue troubleshootingCustomerIssue)
        {
            _troubleshootingCustomerIssue = troubleshootingCustomerIssue;
        }

        public static string RandomTicketString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const int length = 10;
            Random random = new Random();
            string randomString = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }

        public async Task<string> GenerateTicketID()
        {
            var trailer = true;
            var FinalTicketID = "";
            while (trailer)
            {
                if(!await _troubleshootingCustomerIssue.DuplicateTicketCheck(ticketID = RandomTicketString()))
                {
                    FinalTicketID = ticketID;
                    trailer = false;
                }
            }
            return FinalTicketID;
        }
    }
}
