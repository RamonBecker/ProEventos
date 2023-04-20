using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contratos;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class GeralPersist: IGeralPersist
    {
        private readonly ProEventosContext _context;

        public GeralPersist(ProEventosContext context)
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
    }
}
