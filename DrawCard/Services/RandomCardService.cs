using DrawCard.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            while (num > 13)
            {
                num -= 13;
            }
            return num switch
            {
                1 => "Ace",
                11 => "Jack",
                12 => "Queen",
                13 => "King",
                _ => num.ToString()
            };
        }
        static string CardType(int num)
        {
            return num switch
            {
                <= 13 => "Hearts",
                <= 26 => "Clubs",
                <= 39 => "Diamonds",
                <= 52 => "Spades",
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
