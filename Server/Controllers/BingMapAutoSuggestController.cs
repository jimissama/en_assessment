using EN.Shared;
using Microsoft.AspNetCore.Mvc;
using Server.Services.BingMap;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BingMapAutoSuggestController : ControllerBase
    {
        private readonly IBingMapAutoSuggestService _bingMapAutoSuggestService;

        public BingMapAutoSuggestController(IBingMapAutoSuggestService bingMapAutoSuggestService)
        {
            _bingMapAutoSuggestService = bingMapAutoSuggestService;
        }

        [HttpPost]
        public async Task<IActionResult> BingMapBusinessData(BingMapAutoSuggestRequest request)
        {

            return Ok(await _bingMapAutoSuggestService.GetValuesAsync(request));
        }
    }
}