using Cysharp.Threading.Tasks;

namespace CardsService.DeckStrategy
{
    public class WhenImageReady : IDeckStrategy
    {
        public WhenImageReady() 
        {
            _HTTPController = new HTTPController();
            _cardAnimationController = new CardAnimationController();
        }

        public string Name => Constant.WhenImageReadyStrategy;

        private readonly IHTTPController _HTTPController;

        private readonly ICardAnimationController _cardAnimationController;

        public async UniTask LoadImagesAsync(Card[] cards)
        {

        }
    }
}
