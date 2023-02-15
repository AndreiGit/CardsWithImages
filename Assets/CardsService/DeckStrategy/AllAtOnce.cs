using CardsService.CardStates;
using Cysharp.Threading.Tasks;
using System;

namespace CardsService.DeckStrategy
{
    public class AllAtOnce : IDeckStrategy
    {
        public AllAtOnce() 
        {
            _HTTPController = new HTTPController();
            _cardAnimationController = new CardAnimationController();
        }

        public string Name => Constant.AllAtOnceStrategy;

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

            var cardsFlipFront = cards.Select(async card =>
            {
                await _cardAnimationController.PlayAnimationAsync<Front>(card);
            });

            await UniTask.WhenAll(cardsFlipFront);
        }
    }
}
