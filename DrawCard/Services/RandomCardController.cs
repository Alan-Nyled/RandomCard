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
        public RandomCardController(IRandomCardService randomCardService)
        {
            this.randomCardService = randomCardService;
        }

        [HttpGet("/and-put-it-back")]
        public Card GetCard()
        {
            return randomCardService.GetRandomCard();
        }



        [HttpGet("/and-keep-it")]
        public Card GetCardOnce()
        {
            return randomCardService.GetRandomCardAndKeepIt();
    }

    }
}
