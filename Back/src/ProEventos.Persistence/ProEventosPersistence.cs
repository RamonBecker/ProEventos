
using ProEventos.Domain;
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

        public Task<Evento[]> GetAllEventosAsync(bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        public Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos)
        {
            throw new System.NotImplementedException();
        }

        public Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEventos)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        public Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEventos)
        {
            throw new System.NotImplementedException();
        }
    }
}
