using SolicitorInfo.Models;

namespace SolicitorInfo.Repository
{
    public interface ISolicitorRepository
    {
        List<SolicitorItem> GetAll();
        Task AddRangeAsync(List<SolicitorItem> items);
        Task SaveChangesAsync();
    }
}