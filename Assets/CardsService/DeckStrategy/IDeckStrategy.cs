using Cysharp.Threading.Tasks;

namespace CardsService.DeckStrategy
{
    public interface IDeckStrategy
    {
        public string Name { get; }

        public UniTask LoadImagesAsync(Card[] cards);
    }
}
