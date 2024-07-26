using ChallengeSND.Data.Models;

namespace ChallengeSND.Data.Repositories.Interfaces
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Task<IEnumerable<Paciente>> GetAllAsync();
        Task<Paciente> GetByIdAsync(int id);
        Task AddAsync(Paciente paciente);
        Task UpdateAsync(Paciente paciente);
        Task DeleteAsync(int id);
    }
}
