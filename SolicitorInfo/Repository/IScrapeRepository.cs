using SolicitorInfo.Models;

namespace SolicitorInfo.Repository;

public interface IScrapeRepository
{
    public Task<List<SolicitorItem>> GetSolicitorItems();

    public Task<SolicitorItem?> GetSolicitorItem(long id);

    public Task PostSolcitorItem(SolicitorItem solicitoritem);
}