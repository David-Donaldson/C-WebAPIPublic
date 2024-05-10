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
    public class PortfolioController : Controller
    {
        private readonly IPortfolioContactForm _portfolioContactForm;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IGoogleCaptchaService _googleCaptchaService;

        public PortfolioController(IPortfolioContactForm portfolioContactForm, IMapper mapper, IEmailService emailService, IGoogleCaptchaService googleCaptchaService)
        {
            _portfolioContactForm = portfolioContactForm;
            _mapper = mapper;
            _emailService = emailService;
            _googleCaptchaService = googleCaptchaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPortfolioContacts()
        {
            var PortfolioContacts = _mapper.Map<List<PortfolioContact>>(await _portfolioContactForm.GetPortfolioContacts());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(PortfolioContacts);
        }

        [HttpPost("contactForm")]
        public async Task<IActionResult> PostContactForm(ContactFormDTO BindingModel, string captchaToken)
        {
            try
            {
                if (BindingModel == null || !ModelState.IsValid)
                    return BadRequest(ModelState);

                var googleCaptchaResponse = await _googleCaptchaService.GetTokenCaptchaResponse(captchaToken);

                if (!googleCaptchaResponse)
                {
                    ModelState.AddModelError("", "Something went wrong Validating Captcha");
                    return StatusCode(500, ModelState);
                }

                var PortfolioContactMap = _mapper.Map<PortfolioContact>(BindingModel);

                if (!_emailService.ValidateEmail(PortfolioContactMap.EmailAddress))
                {
                    ModelState.AddModelError("", "Inavlid Email Address");
                    return StatusCode(500, ModelState);
                }

                var EmailResponse = await _emailService.SendEmail(EmailTemplate.PortfolioTemplate, BindingModel, "Portfolio");

                if (EmailResponse)
                    PortfolioContactMap.EmailSent = true;

                if (!(await _portfolioContactForm.CreatePortfolioContactForm(PortfolioContactMap)))
                {
                    ModelState.AddModelError("", "Something went wrong when creating entry.");
                    return StatusCode(500, ModelState);
                }

                return Ok(BindingModel);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message});
            }
        }

    }
}
