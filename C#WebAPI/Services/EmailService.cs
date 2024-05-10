using Azure.Core.Serialization;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using PortfolioNoIdentityAPI.DTO;
using PortfolioNoIdentityAPI.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Text.RegularExpressions;

namespace PortfolioNoIdentityAPI.Services
{
    public class EmailService: IEmailService
    {
        private readonly string? _KeyVault;
        private readonly SecretClient _secretClient;

        public EmailService(IConfiguration configuration)
        {
            _KeyVault = configuration["AzureKeyVaultUrl"];
            _secretClient = new SecretClient(new Uri(_KeyVault), new DefaultAzureCredential());
        }

        public async Task<bool> SendEmail(string templateName, ContactFormDTO contactformDTO, string sentFromDomain)
        {
            if (!ValidateEmail(contactformDTO.EmailAddress))
                return false;
            var SENDGRIDAPIKEY = await _secretClient.GetSecretAsync("PortfolioSendgridAPI");
            var client = new SendGridClient(SENDGRIDAPIKEY.Value.Value);
            var msg = new SendGridMessage();
            msg.SetFrom(sentFromDomain + "@ezsolutionz.xyz", sentFromDomain);
            msg.AddTo(contactformDTO.EmailAddress);
            msg.SetTemplateId(templateName);
            msg.SetTemplateData(new
            {
                fullName = contactformDTO.ContactName
            });
            var response = await client.SendEmailAsync(msg);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> SendEmail(string templateName, TroubleshootingCustomerIssueDTO customerIssueDTO, string sentFromDomain, string TicketNumber)
        {
            if (!ValidateEmail(customerIssueDTO.EmailAddress))
                return false;
            var SENDGRIDAPIKEY = await _secretClient.GetSecretAsync("PortfolioSendgridAPI");
            var client = new SendGridClient(SENDGRIDAPIKEY.Value.Value);
            var msg = new SendGridMessage();
            msg.SetFrom(sentFromDomain + "@ezsolutionz.xyz", sentFromDomain);
            msg.AddTo(customerIssueDTO.EmailAddress);
            msg.SetTemplateId(templateName);
            msg.SetTemplateData(new
            {
                fullName = customerIssueDTO.CustomerName,
                ticketID = TicketNumber
            });
            var response = await client.SendEmailAsync(msg);
            return response.IsSuccessStatusCode;
        }

        public bool ValidateEmail(string emailAddress)
        {
            if(string.IsNullOrWhiteSpace(emailAddress))
                return false;
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(emailAddress, emailPattern);
        }
    }
}
