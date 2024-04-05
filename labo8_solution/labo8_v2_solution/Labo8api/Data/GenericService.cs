using Microsoft.EntityFrameworkCore;

namespace Labo8api.Data
{
    public class GenericService<T> where T : class
    {
        protected readonly Labo8apiContext _context;

        public GenericService(Labo8apiContext context){
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T?> Get(int id)
        {
            if (_context.Set<T>() == null)
            {
                return null;
            }
            var t = await _context.Set<T>().FindAsync(id);
            if (t == null)
            {
                return null;
            }
            return t;
        }

        public async Task<T?> Post(T t)
        {
            if (_context.Set<T>() == null)
            {
                return null;
            }
            _context.Set<T>().Add(t);
            await _context.SaveChangesAsync();

            return t;
        }

        public async Task Delete(int id)
        {
            if (_context.Set<T>() == null)
            {
                return;
            }
            var t = await _context.Set<T>().FindAsync(id);
            if (t == null)
            {
                return;
            }
            _context.Set<T>().Remove(t);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> Put(int id, T t)
        {
            _context.Entry(t).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.Set<T>().FindAsync(id) == null)
                {
                    return null; // Entité a été supprimée entretemps
                }
                else
                {
                    throw; // Entité a été modifiée entretemps
                }
            }

            return t;
        }
    }
}
