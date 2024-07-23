using ChallengeSND.Business.DTOS;
using ChallengeSND.data.Responses;

namespace ChallengeSND.Business.Servicies.Interfaces
{
    public interface IAccountService
    {
        public Task<CustomResponses.RegistrationResponse> RegisterAsync(RegisterDTO model);
        public Task<CustomResponses.LoginResponse> LoginAsync(LoginDTO model);
    }
}
