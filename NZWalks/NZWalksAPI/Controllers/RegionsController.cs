using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {
            this._regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAllAsync();

            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegion")]
        public async Task<IActionResult> GetRegion(Guid id)
        {
            var region = await _regionRepository.GetAsync(id);

            return region == null ? NotFound("Request record not found") : Ok(region);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion(Region region)
        {
            var newRegion = await _regionRepository.AddRegion(region);
            return CreatedAtAction(nameof(GetRegion), new { id = region.Id }, newRegion);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var region = await _regionRepository.DeleteRegion(id);

            return region == null ? NotFound() : Ok(region);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegion(Guid id, Region region)
        {
            var updatedRegion = await _regionRepository.UpdateRegion(id, region);

            return region == null ? NotFound() : Ok(updatedRegion);

        }
    }
}
