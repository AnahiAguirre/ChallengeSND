using ChallengeSND.Data.Models;

namespace ChallengeSND.Data.Repositories.Interfaces
{
    public interface IAccountRepository : IRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetUser(string email);
    }
}
