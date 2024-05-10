using Microsoft.EntityFrameworkCore;
using PortfolioNoIdentityAPI.Data;
using PortfolioNoIdentityAPI.Interfaces;
using PortfolioNoIdentityAPI.Models;

namespace PortfolioNoIdentityAPI.Repositories
{
    public class PortairLogixtixContactRepository: IPortairLogistixContactForm
    {
        private readonly DataContext _context;

        public PortairLogixtixContactRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<PortairLogistixContact>> GetPortairLogistixContacts() {
            return await _context.PortairLogistixContacts.ToListAsync();           
        }

        public async Task<PortairLogistixContact> GetPortairLogistixContact(int id)
        {
            return await _context.PortairLogistixContacts.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public bool PortairLogistixContactExists(int id) {
            return _context.PortairLogistixContacts.Any(x => x.Id == id);
        }

        public async Task<bool> CreatePortAirLogistixForm(PortairLogistixContact portairLogistixContact)
        {
             await _context.AddAsync(portairLogistixContact);
            return Save();
        }

        public bool UpdatePortairLogistixForm(PortairLogistixContact portairLogistixContact)
        {
            _context.Update(portairLogistixContact);
            return Save();
        }

        public bool DeletePortairLogistixForm(PortairLogistixContact portairLogistixContact)
        {
            _context.Remove(portairLogistixContact);
            return Save();
        }

        public bool Save()
        {
            var Saved = _context.SaveChanges();
            return Saved > 0? true: false;
        }
    }
}
