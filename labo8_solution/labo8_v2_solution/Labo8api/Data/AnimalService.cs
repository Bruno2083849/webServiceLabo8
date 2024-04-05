using Labo8api.Models;

namespace Labo8api.Data
{
    public class AnimalService : GenericService<Animal>
    {
        public AnimalService(Labo8apiContext context) : base(context){}
        public async Task DeleteAll()
        {
            if (_context.Animal == null)
            {
                return;
            }
            _context.Animal.RemoveRange(_context.Animal);
            await _context.SaveChangesAsync();
        }
    }
}
