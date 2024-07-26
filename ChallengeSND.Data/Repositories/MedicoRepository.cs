﻿using ChallengeSND.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeSND.Data.Repositories
{
    public class MedicoRepository : Repository<Medico>, IMedicoRepository
    {
        private readonly AppDbContext _context;

        public MedicoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medico>> GetMedicosByEspecialidadAsync(string especialidad)
        {
            return await _context.Medicos
                .Where(m => m.Especialidad == especialidad)
                .ToListAsync();
        }
    }
}
