using CardsService.CardStates;
using Cysharp.Threading.Tasks;

namespace CardsService.DeckStrategy
{
    public class OneByOne : IDeckStrategy
    {
        public OneByOne()
        {
            _HTTPController = new HTTPController();
            _cardAnimationController = new CardAnimationController();
        }

        public string Name => Constant.OneByOneStrategy;

        private readonly IHTTPController _HTTPController;

        private readonly ICardAnimationController _cardAnimationController;

        public async UniTask LoadImagesAsync(Card[] cards)
        {
            var cardsFlipBack = cards.Select(async card =>
            {
                var texture = _HTTPController.GetTextureAsync();

                await _cardAnimationController.PlayAnimationAsync<Shirt>(card);

                card.SetTexture(await texture);
            });

            await UniTask.WhenAll(cardsFlipBack);

            foreach (var card in cards)
                await _cardAnimationController.PlayAnimationAsync<Front>(card);
        }
    }
}
