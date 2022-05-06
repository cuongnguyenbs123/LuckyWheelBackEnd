using LuckyWheel.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuckyWheel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IPrizeServices _prizes;
        public HomeController(IPrizeServices prize)
        {
            _prizes = prize;
        }
        [HttpGet]
        public IActionResult GetPrizes()
        {
            return Ok(_prizes.GetPrizes());
        }
    }
}
