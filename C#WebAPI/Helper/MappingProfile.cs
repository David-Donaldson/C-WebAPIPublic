using AutoMapper;
using PortfolioNoIdentityAPI.DTO;
using PortfolioNoIdentityAPI.Models;

namespace PortfolioNoIdentityAPI.Helper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<PortairLogistixContact, ContactFormDTO>();
            CreateMap<ContactFormDTO, PortairLogistixContact>();
            
            CreateMap<PortfolioContact, ContactFormDTO>();
            CreateMap<ContactFormDTO, PortfolioContact>();

            CreateMap<TroubleshootingCustomerIssue, TroubleshootingCustomerIssueDTO>();
            CreateMap<TroubleshootingCustomerIssueDTO, TroubleshootingCustomerIssue>();

        }
    }
}
