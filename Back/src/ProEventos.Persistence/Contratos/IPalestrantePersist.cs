using ProEventos.Domain;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
        // PALESTRANTES

        Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos);
        Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEventos);
    }
}