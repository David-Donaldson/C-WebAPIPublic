namespace PortfolioNoIdentityAPI.Interfaces
{
    public interface IGoogleCaptchaService
    {
        public Task<bool> GetTokenCaptchaResponse(string userResponseToken);

    }
}
