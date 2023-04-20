using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;

        public PalestrantePersist(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos = false)
        {
            var query = _context.Palestrantes.Include(p => p.RedesSociais).AsQueryable<Palestrante>();

            if (includeEventos)
            {
                query = query
                            .Include(p => p.PalestrantesEventos)
                            .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEventos)
        {
            var query = _context.Palestrantes.Include(p => p.RedesSociais).AsQueryable<Palestrante>();

            if (includeEventos)
            {
                query = query
                            .Include(p => p.PalestrantesEventos)
                            .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEventos)
        {
            var query = _context.Palestrantes.Include(p => p.RedesSociais).AsQueryable<Palestrante>();

            if (includeEventos)
            {
                query = query
                            .Include(p => p.PalestrantesEventos)
                            .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
