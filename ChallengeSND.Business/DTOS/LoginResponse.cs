using ChallengeSND.Data.Responses;

namespace ChallengeSND.Business.DTOS
{
    public class LoginResponse : CustomResponses
    {
        public string Token { get; set; } = string.Empty;
    }
}
