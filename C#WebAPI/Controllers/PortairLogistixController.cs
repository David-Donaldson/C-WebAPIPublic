using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioNoIdentityAPI.DTO;
using PortfolioNoIdentityAPI.Helper;
using PortfolioNoIdentityAPI.Interfaces;
using PortfolioNoIdentityAPI.Models;

namespace PortfolioNoIdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortairLogistixController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPortairLogistixContactForm _portairLogistixContactForm;
        private readonly IEmailService _Emailservice;
        private readonly IGoogleCaptchaService _googleCaptchaService;

        public PortairLogistixController(IPortairLogistixContactForm portairLogistixContactForm, IMapper mapper, IEmailService emailservice, IGoogleCaptchaService googleCaptchaService)
        {
            _mapper = mapper;
            _portairLogistixContactForm = portairLogistixContactForm;
            _Emailservice = emailservice;
            _googleCaptchaService = googleCaptchaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPortairLogistixContacts() 
        {
            var PortairLogistixContacts = await _portairLogistixContactForm.GetPortairLogistixContacts();
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(PortairLogistixContacts);
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

                var PortairLogistixFormMap = _mapper.Map<PortairLogistixContact>(BindingModel);

                if (!_Emailservice.ValidateEmail(PortairLogistixFormMap.EmailAddress))
                {
                    ModelState.AddModelError("", "Invalid Email Address");
                    return StatusCode(500, ModelState);
                }

                var EmailResponse = await _Emailservice.SendEmail(EmailTemplate.PortairLogistixTemplate, BindingModel, "PortairLogistix");

                if (EmailResponse)
                    PortairLogistixFormMap.EmailSent = true;

                if (!(await _portairLogistixContactForm.CreatePortAirLogistixForm(PortairLogistixFormMap)))
                {
                    ModelState.AddModelError("", "Something went wrong when creating entry.");
                    return StatusCode(500, ModelState);
                }

                return Ok(BindingModel);
            }
            catch(Exception e)
            {
                return BadRequest(new { message = e.Message});
            }
        }
    }
}
