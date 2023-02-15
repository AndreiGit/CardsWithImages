using CardsService.CardStates;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.UIElements;

namespace CardsService.DeckStrategy
{
    public class AllAtOnce : IDeckStrategy
    {
        public AllAtOnce() 
        {
            _HTTPController = new();
        }

        private readonly HTTPController _HTTPController;

        public string Name => Constant.AllAtOnceStrategy;

        public async UniTask LoadImagesAsync(Card[] cards)
        {
            var cardsFlipBack = cards.Select(async card =>
            {
                //проигрывание анимации
                await PlayAnimationAsync(card);

                //скачивание текстуры с сайта
                var texture = await _HTTPController.GetTextureAsync();

                //установка текстуры
                card.SetTexture(texture);
            });

            //одновременный поворот рубашкой вверх
            await UniTask.WhenAll(cardsFlipBack);

            //одновременный поворот картикой вверх
        }

        private async UniTask PlayAnimationAsync(Card card)
        {
            //переворот рубашкой вниз
            card.CardContainer.RemoveFromClassList("cardcontainer-scale-out");
            card.CardContainer.AddToClassList("cardcontainer-scale-in");
            await UniTask.Delay(TimeSpan.FromSeconds(0.3f));

            //изменение состояния карты
            card.CardStateProvider.SetState<Front>();

            //разворот картикой вверх
            card.CardContainer.RemoveFromClassList("cardcontainer-scale-in");
            card.CardContainer.AddToClassList("cardcontainer-scale-out");
        }
    }
}
