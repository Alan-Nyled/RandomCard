using DrawCard.Models;

namespace DrawCard.Services
{
    public interface IRandomCardService
    {
        public Task<Card> GetRandomCard();

    }
}
