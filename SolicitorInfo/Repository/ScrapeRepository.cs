using SolicitorInfo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace SolicitorInfo.Repository;

public class ScrapeRepository : IScrapeRepository

{
    // move comms between controller and context and reassign to repository
    private readonly SolicitorContext _solicitorContext;

    public ScrapeRepository(SolicitorContext solicitorContext)
    {
        _solicitorContext = solicitorContext;
    }

    public async Task<List<SolicitorItem>> GetSolicitorItems()
    {
        return await _solicitorContext.SolicitorItems.ToListAsync();
    }

    public async Task<SolicitorItem?> GetSolicitorItem(long id)
    {
        return await _solicitorContext.SolicitorItems.FindAsync(id);
    }

    public async Task PostSolcitorItem(SolicitorItem solicitoritem)
    {
        // Tells EF Core: “This object represents an existing row, and its values have changed.”
        _solicitorContext.SolicitorItems.Add(solicitoritem);
        // SaveChangesAsync() commits the changes to the database with a SQL UPDATE.
        await _solicitorContext.SaveChangesAsync();
    }


    
}