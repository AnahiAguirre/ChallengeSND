using ChallengeSND.Data.Models;
using ChallengeSND.Data.Repositories;
using ChallengeSND.Data.Repositories.Interfaces;

namespace ChallengeSND.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
           
            return new Repository<T>(_context);
        }
    }
}
