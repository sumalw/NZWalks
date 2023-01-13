using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();

        Task<Region> GetAsync(Guid id);

        Task<Region> AddRegion(Region region);
        
        Task<Region> DeleteRegion(Guid id);

        Task<Region> UpdateRegion(Guid id, Region region);
    }
}
