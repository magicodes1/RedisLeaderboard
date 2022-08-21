using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisPractice.Models;
using RedisPractice.Services;

namespace RedisPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankController : ControllerBase
    {
        private readonly IRankService _rankService;

        public RankController(IRankService rankService)
        {
            _rankService = rankService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int start, int end) => 
                                                    Ok(await _rankService.Range(start, end));

        [HttpPost]
        public async Task<IActionResult> Create(GetScoreRequest request)
        {
            var result = await _rankService.Update(request);

            return Ok(result);
        }
    }
}
