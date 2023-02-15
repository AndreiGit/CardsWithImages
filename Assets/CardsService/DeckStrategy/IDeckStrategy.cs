using Cysharp.Threading.Tasks;
using System.Threading;

namespace CardsService.DeckStrategy
{
    public interface IDeckStrategy
    {
        public string Name { get; }

        public UniTask LoadImagesAsync(ICard[] cards, CancellationToken cancellationToken);
    }
}
