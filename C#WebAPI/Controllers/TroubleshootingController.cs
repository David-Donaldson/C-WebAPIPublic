using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioNoIdentityAPI.DTO;
using PortfolioNoIdentityAPI.Interfaces;
using PortfolioNoIdentityAPI.Models;
using PortfolioNoIdentityAPI.Helper;

namespace PortfolioNoIdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TroubleshootingController : Controller
    {
        private readonly ITroubleshootingCustomerIssue _troubleshootingCustomerIssue;
        private readonly ITroubleshootingServiceType _troubleshootingServiceType;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IGoogleCaptchaService _googleCaptchaService;

        public TroubleshootingController(ITroubleshootingCustomerIssue troubleshootingCustomerIssue, ITroubleshootingServiceType troubleshootingServiceType, IMapper mapper, IEmailService emailService, IGoogleCaptchaService googleCaptchaService)
        {
            _troubleshootingCustomerIssue = troubleshootingCustomerIssue;
            _troubleshootingServiceType = troubleshootingServiceType;
            _emailService = emailService;
            _mapper = mapper;
            _googleCaptchaService = googleCaptchaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerIssue()
        {
            var TroubleshootingCustomerIssues = await _troubleshootingCustomerIssue.GetTroubleshootingCustomerIssues();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(TroubleshootingCustomerIssues);
        }

        [HttpGet("getServiceTypes")]
        public async Task<IActionResult> GetServiceTypes()
        {
            var TroubleshootingServiceTypes = await _troubleshootingServiceType.GetTroubleshootingServiceTypes();
            return Ok(TroubleshootingServiceTypes);
        }

        [HttpPost("createIssue")]
        public async Task<IActionResult> CreateCustomerIssue(TroubleshootingCustomerIssueDTO BindingModel, string CaptchaToken)
        {
            try {
                if (BindingModel == null || !ModelState.IsValid)
                    return BadRequest(ModelState);

                var googleCaptchaResponse = await _googleCaptchaService.GetTokenCaptchaResponse(CaptchaToken);

                if (!googleCaptchaResponse)
                {
                    ModelState.AddModelError("", "Something went wrong validating Captchza");
                    return StatusCode(500, ModelState);
                }

                var TroubleshootingCustomerIssueFormMap = _mapper.Map<TroubleshootingCustomerIssue>(BindingModel);

                if (!_emailService.ValidateEmail(TroubleshootingCustomerIssueFormMap.EmailAddress))
                {
                    ModelState.AddModelError("", "Invalid Email Address");
                    return StatusCode(500, ModelState);
                }

                //If email fails after database record has been saved, create some service worker to to go through all emails in DB with emails not yet sent & retry sending.

                TroubleshootingHelper troubleshootingHelper = new TroubleshootingHelper(_troubleshootingCustomerIssue);
                var TicketID = await troubleshootingHelper.GenerateTicketID();

                TroubleshootingCustomerIssueFormMap.TicketID = TicketID;

                var EmailResponse = await _emailService.SendEmail(EmailTemplate.TroubleshootingServiceTemplate, BindingModel, "TroubleShooting", TicketID);

                if (EmailResponse)
                    TroubleshootingCustomerIssueFormMap.EmailSent = true;

                if (!(await _troubleshootingCustomerIssue.CreateCustomerIssue(TroubleshootingCustomerIssueFormMap)))
                {
                    ModelState.AddModelError("", "Something went wrong when creating entry.");
                    return StatusCode(500, ModelState);
                }

                return Ok(BindingModel);
            }
            catch(Exception ex) { 
                return BadRequest( new { message = ex.Message });
            }
        }


    }
}
