using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class EventoPersist: IEventoPersist
    {

        private readonly ProEventosContext _context;

        public EventoPersist(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            var query = _context.Eventos
                                 .Include(e => e.Lotes)
                                 .Include(e => e.RedesSociais).AsQueryable<Evento>();

            if (includePalestrantes)
            {
                query = query
                            .Include(e => e.PalestrantesEventos)
                            .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            var query = _context.Eventos
                     .Include(e => e.Lotes)
                     .Include(e => e.RedesSociais).AsQueryable<Evento>();
            if (includePalestrantes)
            {
                query = query
                            .Include(e => e.PalestrantesEventos)
                            .ThenInclude(pe => pe.Palestrante);
            }

            query = query
                         .OrderBy(e => e.Id)
                         .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes)
        {
            var query = _context.Eventos
                                 .Include(e => e.Lotes)
                                 .Include(e => e.RedesSociais).AsQueryable<Evento>();

            if (includePalestrantes)
            {
                query = query
                            .Include(e => e.PalestrantesEventos)
                            .ThenInclude(pe => pe.Palestrante);
            }

            query = query
                         .OrderBy(e => e.Id)
                         .Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
