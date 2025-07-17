using Microsoft.AspNetCore.Mvc;
using ClaimManagement.Domain;
using ClaimManagement.Application;

namespace ClaimManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimDataAccess _claimRepository;

        public ClaimsController(IClaimDataAccess claimRepository)
        {
            _claimRepository = claimRepository;
        }


        [HttpPost]
        public async Task<IActionResult> FileClaim([FromBody] Claim claim)
        {
            await _claimRepository.AddAsync(claim);
            return CreatedAtAction(nameof(GetClaimById), new { id = claim.Id }, claim);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClaimById(string id)
        {
            var claim = await _claimRepository.GetByIdAsync(id);
            if (claim == null)
                return NotFound();
            return Ok(claim);

        }

        [HttpGet]
        public async Task<IActionResult> GetClaimsByPolicyId([FromQuery] string PolicyId)
        {
            var claims = await _claimRepository.GetByPolicyIdAsync(PolicyId);
            return Ok(claims);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateClaimStatus(string id, [FromBody] ClaimStatusUpdateDto updateDto)
        {
            var existingClaim=await _claimRepository.GetByIdAsync(id);
            if (existingClaim == null)
                return NotFound();

            existingClaim.Status = updateDto.Status;
            await _claimRepository.UpdateAsync(existingClaim);

            return NoContent();

        }

        [HttpPost("{id}/notes")]
        public async Task<IActionResult> AddNotes(string id, [FromBody] ClaimNote note)
        {
            var existingClaim=await _claimRepository.GetByIdAsync(id);
            if(existingClaim == null)
                return NotFound();

            existingClaim.Notes.Add(note);
            await _claimRepository.UpdateAsync(existingClaim);
            return NoContent();

        }
    }

}
