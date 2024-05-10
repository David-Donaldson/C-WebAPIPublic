using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Newtonsoft.Json;
using PortfolioNoIdentityAPI.Interfaces;

namespace PortfolioNoIdentityAPI.Services
{
    public class GoogleCaptchaService: IGoogleCaptchaService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly string? _keyVault;
        private readonly string? _captchaUrl;
        private readonly SecretClient _secretClient;

        public GoogleCaptchaService(IConfiguration configuration, HttpClient httpClient)
        {
            _keyVault = configuration["AzureKeyVaultUrl"];
            _captchaUrl = configuration["GoogleCaptchaUrl"];
            _secretClient = new SecretClient(new Uri(_keyVault), new DefaultAzureCredential());
            _httpClient = httpClient;
        }

        public async Task<bool> GetTokenCaptchaResponse(string userResponseToken)
        {
            var reCaptchaSecretKey = await _secretClient.GetSecretAsync("GoogleCaptchaSecretKey");

            if (reCaptchaSecretKey != null && userResponseToken != null)
            {
                var secretKey = reCaptchaSecretKey.Value.Value;
                var response = await _httpClient.GetAsync($"{_captchaUrl}?secret={secretKey}&response={userResponseToken}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var googleResult = JsonConvert.DeserializeObject<reCaptchaResponse>(result);
                    return googleResult.Success && googleResult.Score >= 0.5;
                }
            }
            return false;
        }

        public class reCaptchaResponse
        {
            public bool Success { get; set; }
            public double Score { get; set; }
        }
    }
}
