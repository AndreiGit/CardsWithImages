using CardsService.CardStates;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace CardsService.DeckStrategy
{
    public class OneByOne : IDeckStrategy
    {
        public OneByOne(IHTTPController HTTPController, ICardAnimationController cardAnimationController)
        {
            _HTTPController = HTTPController;
            _cardAnimationController = cardAnimationController;
        }

        public string Name => Constant.OneByOneStrategy;

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

            foreach (var card in cards)
            {
                cancellationToken.ThrowIfCancellationRequested();

                await _cardAnimationController.PlayAnimationAsync<Front>(card);
            }
        }
    }
}
