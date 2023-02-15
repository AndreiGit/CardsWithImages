using Cysharp.Threading.Tasks;
using System.Threading;

namespace CardsService.DeckStrategy
{
    public interface IDeckStrategy
    {
        public string Name { get; }

        public UniTask LoadImagesAsync(Card[] cards, CancellationToken cancellationToken);
    }
}
