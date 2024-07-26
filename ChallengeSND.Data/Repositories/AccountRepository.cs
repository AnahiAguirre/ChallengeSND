using ChallengeSND.Data.Models;
using ChallengeSND.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChallengeSND.Data.Repositories
{
    public class AccountRepository : Repository<ApplicationUser>, IAccountRepository
    {
        private readonly AppDbContext _context;
        public AccountRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<ApplicationUser?> GetUser(string email)
        {
            return await _context.User
                .FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
