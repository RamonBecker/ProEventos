
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext _context;

        public ProEventosPersistence(ProEventosContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveChangesAsync()
        {
            // Verifica se foi realizado alguma alteração no BD
            return (await _context.SaveChangesAsync()) > 0;
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entities) where T : class
        {
            _context.RemoveRange(entities);
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
                         .Where(e => e.Tema.ToLower().Contains(tema.ToLower())));

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
