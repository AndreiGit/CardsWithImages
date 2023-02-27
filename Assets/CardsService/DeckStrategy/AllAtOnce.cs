using CardsService.CardStates;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

namespace CardsService.DeckStrategy
{
    public class AllAtOnce : IDeckStrategy
    {
        public AllAtOnce(IHTTPController HTTPController, ICardAnimationController cardAnimationController) 
        {
            _HTTPController = HTTPController;
            _cardAnimationController = cardAnimationController;
        }

        public string Name => Constant.AllAtOnceStrategy;

        private readonly IHTTPController _HTTPController;

        private readonly ICardAnimationController _cardAnimationController;

        public async UniTask LoadImagesAsync(ICard[] cards, CancellationToken cancellationToken)
        {
            var cardsFlipBack = cards.Select(async card =>
            {
                var texture = _HTTPController.GetTextureAsync(cancellationToken);

                await _cardAnimationController.PlayAnimationAsync<Shirt>(card);

                card.SetTexture(await texture);
            });

            await UniTask.WhenAll(cardsFlipBack);

            var cardsFlipFront = cards.Select(async card =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                await _cardAnimationController.PlayAnimationAsync<Front>(card);
            });

            await UniTask.WhenAll(cardsFlipFront);
        }
    }
}
