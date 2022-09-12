using DrawCard.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DrawCard.Services
{
    [Route("/")]
    [EnableCors("AllowSpecificOrigins")]
    [ApiController]
    [Produces("application/json")]
    public class RandomCardService : IRandomCardService
    {
        static int RandomCard()
        {
            Random rand = new();
            return rand.Next(1, 56);
        }
        static string CardValue(int num)
        {
            if (num > 52) { return string.Empty; }
            return (num % 13) switch
            {
                1 => "Es",
                11 => "Knægt",
                12 => "Dame",
                0 => "Konge",
                _ => (num % 13).ToString()
            };
        }
        static string CardType(int num)
        {
            return num switch
            {
                <= 13 => "Hjerter",
                <= 26 => "Klør",
                <= 39 => "Ruder",
                <= 52 => "Spar",
                _ => "Joker",
            };
        }
        
        [HttpGet()]        
        public async Task<Card> GetRandomCard()
        {
            int num = RandomCard();
            Card card =  await Task.FromResult(new Card
            {
                Type = CardType(num),
                Value = CardValue(num),
                Random = num
            });
            Console.WriteLine($"{ card.Type} {card.Value}");
            return card;

        }
    }
}
