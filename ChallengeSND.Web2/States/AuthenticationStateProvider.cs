using ChallengeSND.Business.DTOS;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ChallengeSND.Web2.States
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ClaimsPrincipal anonymous = new(new ClaimsIdentity());
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(Constants.JWTToken))
                    return await Task.FromResult(new AuthenticationState(anonymous));

                var getUserClaims = DecryptToken(Constants.JWTToken);
                if (getUserClaims == null) return await Task.FromResult(new AuthenticationState(anonymous));

                var claimsPrincipal = SetClaimPrincipal(getUserClaims);
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (Exception)
            {
                return await Task.FromResult(new AuthenticationState(anonymous));
            }
        }

        public void UpdateAuthenticationState(string jwtToken)
        {
            var claimsPrincipal = new ClaimsPrincipal();
            if (!string.IsNullOrEmpty(jwtToken))
            {
                Constants.JWTToken = jwtToken;
                var getUserClaims = DecryptToken(jwtToken);
                _ = SetClaimPrincipal(getUserClaims);
            }
            else
            {
                Constants.JWTToken = null!;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        private static ClaimsPrincipal SetClaimPrincipal(CustomUserClaims claims)
        {
            if (claims.Email is null) return new ClaimsPrincipal();
            return new ClaimsPrincipal(
                new ClaimsIdentity(
                    [new(ClaimTypes.Name, claims.Name!),
                    new(ClaimTypes.Email, claims.Email!)],
                    "JwtAuth"));
        }

        private static CustomUserClaims DecryptToken(string jwtToken)
        {
            if (string.IsNullOrEmpty(jwtToken)) return new CustomUserClaims();

            var handler = new JwtSecurityTokenHandler();
            var token = new JwtSecurityToken(jwtToken);

            var name = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Name);
            var email = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Email);

            return new CustomUserClaims(name!.Value, email!.Value);
        }
    }
}
