using DrawCard.Models;

namespace DrawCard.Services
{
    public interface IRandomCardService
    {
        Card GetRandomCard();
        Card GetRandomCardAndKeepIt();

    }

    public class RandomCardService : IRandomCardService
    {
        private static List<int> DrawnCards = new();

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
        public Card GetRandomCard()
        {
            int num = RandomCard();
            Card card = new()
            {
                Type = CardType(num),
                Value = CardValue(num),
                Random = num
            };
            Console.WriteLine($"{card.Type} {card.Value}");
            return card;

        }
        public Card GetRandomCardAndKeepIt()
        {
            int num = RandomCard();
            DrawnCards.Add(num);
            DrawnCards.ForEach(i => Console.Write("{0}\t", i));
            Card card = new()
            {
                Type = "HOLD",
                Value = "KÆFT",
                Random = num
            };
            Console.WriteLine($"{card.Type} {card.Value}");
            return card;
        }
    }
}
