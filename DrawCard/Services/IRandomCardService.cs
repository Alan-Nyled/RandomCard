using DrawCard.Models;

namespace DrawCard.Services
{
    public interface IRandomCardService
    {
        Card GetRandomCard();
        Card GetRandomCardMultiple();
        void ResetList();

    }

    public class RandomCardService : IRandomCardService
    {
        private static List<int> DrawnCards = new();

        public void ResetList()
        {
            DrawnCards.Clear();
        }

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
           
            return card;

        }
        public Card GetRandomCardMultiple()
        {
            int num = RandomCard();
            string type;
            string value;

            if (DrawnCards.Count < 55)
            {
                while (DrawnCards.Contains(num))
                {
                    num = RandomCard();
                }

                DrawnCards.Add(num);
                type = CardType(num);
                value = CardValue(num);
            }
            else
            {
                type = "Ingenting.";
                value = "Der er ikke flere kort i bunken.";
                num = 0;
            }
            Card card = new()
            {
                Type = type,
                Value = value,
                Random = num
            };
            
            return card;
        }
    }
}
