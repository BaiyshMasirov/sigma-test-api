using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Common;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Controllers
{
    public class CandidateController : BaseController
    {
        /// <summary>
        /// Upsert candidate
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Result with message</returns>
        [HttpPost("upsert-candidate")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Upsert([FromBody] UpsertCandidateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await Profile.UpsertAsync(request);

            return !result.Succeed
                   ? BadRequest(result)
                   : Ok(result);
        }
    }
}