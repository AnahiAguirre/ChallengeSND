using ChallengeSND.data.Models;
using ChallengeSND.Data.Models;
using ChallengeSND.data.Repositories;
using ChallengeSND.Data.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<ApplicationUser> GetUser(string email)
        {
            return await _context.User
                .FirstAsync(x => x.Email == email);
        }
    }
}
