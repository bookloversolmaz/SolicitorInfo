using SolicitorInfo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace SolicitorInfo.Repository
{
    public class SolicitorRepository : ISolicitorRepository

    {
        // move comms between controller and context and reassign to repository
        private readonly SolicitorContext _solicitorContext;

        public SolicitorRepository(SolicitorContext solicitorContext)
        {
            _solicitorContext = solicitorContext;
        }

        // Read, get everything from the database
        public async Task<List<SolicitorItem>> GetAllAsync() 
        { 
            return await _solicitorContext.SolicitorItems.ToListAsync(); 
        } 
    
        // Create, save multiple results in one go
        // Add range is included here so that it call add multiple items in one call
        public async Task AddRangeAsync(List<SolicitorItem> items) 
        { 
            _solicitorContext.SolicitorItems.AddRange(items); 
            await _solicitorContext.SaveChangesAsync(); 
        }

    }
}