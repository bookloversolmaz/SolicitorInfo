using Microsoft.EntityFrameworkCore;
using SolicitorInfo.Models;

namespace SolicitorInfo.Repository
{
    public class SolicitorRepository : ISolicitorRepository
    {
        private readonly SolicitorContext _context;

        public SolicitorRepository(SolicitorContext context)
        {
            _context = context;
        }

        public List<SolicitorItem> GetAll()
        {
            return _context.SolicitorItems.ToList();
        }

        public async Task AddRangeAsync(List<SolicitorItem> items)
        {
            var existing = _context.SolicitorItems.ToList();

            var newItems = items
                .Where(i => !existing.Any(e =>
                    e.SolicitorName == i.SolicitorName &&
                    e.Address == i.Address))
                .ToList();

            await _context.SolicitorItems.AddRangeAsync(newItems);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}