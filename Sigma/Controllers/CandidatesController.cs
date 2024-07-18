using Microsoft.AspNetCore.Mvc;
using Sigma.Model;
using Sigma.Service.IService;

namespace Sigma.Controllers
{
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost("addEditCandidate")]
        public async Task<ActionResult> AddEditCandidate([FromBody] Candidate candidate)
        {
            if (candidate == null || string.IsNullOrWhiteSpace(candidate.Email))
            {
                return BadRequest("Invalid candidate data");
            }

            try
            {
                var result = await _candidateService.AddOrEditCandidateAsync(candidate);
                string response = string.Empty;
                if (result == "Created")
                {
                    response = "Created Successfully";
                }
                else if (result == "Updated")
                {
                    response = "Updated Successfully";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add or update candidate: {ex.Message}");
            }
        }

    }
}
