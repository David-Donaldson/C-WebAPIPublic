using Microsoft.EntityFrameworkCore;
using PortfolioNoIdentityAPI.Data;
using PortfolioNoIdentityAPI.Interfaces;
using PortfolioNoIdentityAPI.Models;

namespace PortfolioNoIdentityAPI.Repositories
{
    public class PortfolioContactRespoitory: IPortfolioContactForm
    {
        private readonly DataContext _context;

        public PortfolioContactRespoitory(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<PortfolioContact>> GetPortfolioContacts()
        {
            return await _context.PortfolioContacts.ToListAsync();
        }

        public PortfolioContact GetPortfolioContact(int id)
        {
            //return _context.PortfolioContacts.FirstOrDefault(c => c.Id == id);
            return _context.PortfolioContacts.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool PortfolioContactExists(int id)
        {
            return _context.PortairLogistixContacts.Any(c => c.Id == id);
        }

        public async Task<bool> CreatePortfolioContactForm(PortfolioContact portfolioContact)
        {
            await _context.AddAsync(portfolioContact);
            return Save();
        }

        public bool UpdatePortfolioContactForm(PortfolioContact portfolioContact)
        {
            _context.Update(portfolioContact);
            return Save();        
        }

        public bool DeletePortfolioContactForm(PortfolioContact portfolioContact)
        {
            _context.Remove(portfolioContact);
            return Save();
        }

        public bool DeleteMultiplePortfolioContactForm(IEnumerable<PortfolioContact> contacts)
        {
            _context.RemoveRange(contacts);
            return Save();
        }

        public bool Save()
        {
            var Saved = _context.SaveChanges();
            return Saved > 0 ? true : false;
        }
    }
}
