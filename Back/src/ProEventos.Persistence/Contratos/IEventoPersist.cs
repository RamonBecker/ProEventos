using ProEventos.Domain;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventoPersist
    {
        // EVENTOS
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes);
    }
}