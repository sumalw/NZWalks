using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using System.Reflection.Metadata.Ecma335;

namespace NZWalksAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _context;
        public RegionRepository(NZWalksDbContext dbContext)
        {
            this._context = dbContext;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            return region;
        }

        public async Task<Region> AddRegion(Region region)
        {
            region.Id = Guid.NewGuid();
            await _context.AddAsync(region);
            await _context.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteRegion(Guid id)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(region == null)
            {
                return null;
            }
            _context.Remove(region);
            await _context.SaveChangesAsync();
            return region;
        }

        public async Task<Region> UpdateRegion(Guid id, Region region)
        {
            var existingRegion = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await _context.SaveChangesAsync();
            return existingRegion;
        }
    }
}
