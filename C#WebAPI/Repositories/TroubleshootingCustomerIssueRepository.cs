using Microsoft.EntityFrameworkCore;
using PortfolioNoIdentityAPI.Data;
using PortfolioNoIdentityAPI.Interfaces;
using PortfolioNoIdentityAPI.Models;

namespace PortfolioNoIdentityAPI.Repositories
{
    public class TroubleshootingCustomerIssueRepository: ITroubleshootingCustomerIssue
    {
        private readonly DataContext _context;

        public TroubleshootingCustomerIssueRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<TroubleshootingCustomerIssue>> GetTroubleshootingCustomerIssues()
        {
            return await _context.TroubleshootingCustomerIssues.ToListAsync();
        }

        public async Task<bool> CreateCustomerIssue(TroubleshootingCustomerIssue CustomerIssue)
        {
            await _context.AddAsync(CustomerIssue);
            return Save();
        }

        public TroubleshootingCustomerIssue GetCustomerIssue(int CustomerIssueId)
        {
            return _context.TroubleshootingCustomerIssues.Where(x => x.Id == CustomerIssueId).FirstOrDefault();
        }

        public async Task<bool> DuplicateTicketCheck(string TicketID)
        {
            return await _context.TroubleshootingCustomerIssues.Where(x => x.TicketID == TicketID).AnyAsync();  
        }

        public bool Save()
        {
            var Saved = _context.SaveChanges();
            return Saved > 0? true : false;
        }
    }
}
