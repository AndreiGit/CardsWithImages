using Cysharp.Threading.Tasks;

namespace CardsService.DeckStrategy
{
    public class WhenImageReady : IDeckStrategy
    {
        public string Name => Constant.WhenImageReadyStrategy;

        public async UniTask LoadImagesAsync(Card[] cards)
        {

        }
    }
}
