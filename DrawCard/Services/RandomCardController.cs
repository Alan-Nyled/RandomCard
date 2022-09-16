using DrawCard.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DrawCard.Services
{

    [Route("drawcard")]
    [EnableCors("AllowSpecificOrigins")]
    [ApiController]
    [Produces("application/json")]
    public class RandomCardController : ControllerBase
    {
        private readonly IRandomCardService randomCardService;
        public RandomCardController(IRandomCardService _randomCardService)
        {
            this.randomCardService = _randomCardService;
        }

        [HttpGet("/onecard")]
        public Card GetCard()
        {
            return randomCardService.GetRandomCard();
        }

        [HttpGet("/multiplecards")]
        public Card GetCardOnce()
        {
            return randomCardService.GetRandomCardMultiple();
        }

        [HttpGet("/reset")]
        public void Reset()
        {
            randomCardService.ResetList();
        }

    }
}
