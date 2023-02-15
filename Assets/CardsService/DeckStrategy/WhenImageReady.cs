﻿using CardsService.CardStates;
using Cysharp.Threading.Tasks;
using System.Threading;

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

        public async UniTask LoadImagesAsync(Card[] cards, CancellationToken cancellationToken)
        {
            var cardsFlipBack = cards.Select(async card =>
            {
                var texture = _HTTPController.GetTextureAsync();

                await _cardAnimationController.PlayAnimationAsync<Shirt>(card);

                card.SetTexture(await texture);

                await _cardAnimationController.PlayAnimationAsync<Front>(card);
            });

            await UniTask.WhenAll(cardsFlipBack);
        }
    }
}
