using AutoMapper;
using ChallengeSND.Business.DTOS;
using ChallengeSND.Business.Servicies.Interfaces;
using ChallengeSND.Data.Responses;
using ChallengeSND.Data.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using ChallengeSND.Data.Models;

namespace ChallengeSND.Business.Servicies
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _config;
        public AccountService(IAccountRepository accountRepository, IConfiguration config)
        {
            _accountRepository = accountRepository;
            _config = config;
        }
        public async Task<CustomResponses.LoginResponse> LoginAsync(LoginDTO model)
        {
            ApplicationUser? findUser = await _accountRepository.GetUser(model.Email);
            if (findUser == null) return new CustomResponses.LoginResponse(false, "Usuario inexistente");

            if (!BCrypt.Net.BCrypt.Verify(model.Password, findUser!.Password))
                return new CustomResponses.LoginResponse(false, "Email o password incorrecto");

            string jwtToken = new AuthenticationService(_config).GenerateToken(findUser);
            return new CustomResponses.LoginResponse(true, "Loggin exitoso", jwtToken);
        }

        public async Task<CustomResponses.RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            ApplicationUser? findUser = await _accountRepository.GetUser(model.Email);
            if (findUser != null) return new CustomResponses.RegistrationResponse(false, "Usuario existente");

            await _accountRepository.AddAsync(new ApplicationUser()
            {
                Name = model.Name,
                Email = model.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password)
            });

            await _accountRepository.SaveChangesAsync();
            return new CustomResponses.RegistrationResponse(true, "Ok");
        }
    }
}
