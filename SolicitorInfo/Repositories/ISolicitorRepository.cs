using SolicitorInfo.Models;

namespace SolicitorInfo.Repository
{
    public interface ISolicitorRepository
    {
        Task<List<SolicitorItem>> GetAllAsync();

        Task<SolicitorItem?> GetByIdAsync(long id);

        Task AddAsync(SolicitorItem solicitorItem);

        Task AddRangeAsync(List<SolicitorItem> solicitorItems);
    }
}

