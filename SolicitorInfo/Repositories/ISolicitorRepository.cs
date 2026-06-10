using SolicitorInfo.Models;

namespace SolicitorInfo.Repository
{
    public interface ISolicitorRepository
    {
        Task<List<SolicitorItem>> GetAllAsync(string? location = null);
        Task AddRangeAsync(List<SolicitorItem> solicitorItems);
    }
}

