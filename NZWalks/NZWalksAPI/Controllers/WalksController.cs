using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;

        public WalksController(IWalkRepository walkRepository)
        {
            this._walkRepository = walkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walks = await _walkRepository.GetAllAsync();

            return Ok(walks);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalk")]
        public async Task<IActionResult> GetWalk(Guid id)
        {
            var walk = await _walkRepository.GetAsync(id);

            return walk == null ? NotFound() : Ok(walk);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddWalk([FromBody] Models.DTO.AddWalkRequest addWalkRequest)
        //{
        //    var walkDomain = new Models.Domain.Walk
        //    {
        //        Length = addWalkRequest.Length,
        //        Name = addWalkRequest.Name,
        //        RegionId = addWalkRequest.RegionId,
        //        WalkDifficultyId = addWalkRequest.WalkDifficultyId
        //    };

        //    var newWalk = await _walkRepository.AddWalk(walkDomain);

        //    //var walkDTO = new Models.DTO.Walk
        //    //return CreatedAtAction(nameof(GetWalk), new { id = walk.Id}, newWalk);
        //}

    }
}
