using Cysharp.Threading.Tasks;
using System;
using UnityEngine.UIElements;

namespace CardsService.DeckStrategy
{
    public class AllAtOnce : IDeckStrategy
    {
        public string Name => Constant.AllAtOnceStrategy;

        public async UniTask LoadImagesAsync(Card[] cards)
        {
            var cardsFlipBack = cards.Select(async card =>
            {
                await PlayAnimationAsync(card.CardContainer);

            });

            await UniTask.WhenAll(cardsFlipBack);
        }

        private async UniTask PlayAnimationAsync(VisualElement cardContainer)
        {
            //переворот рубашкой вниз
            cardContainer.RemoveFromClassList("cardcontainer-scale-out");
            cardContainer.AddToClassList("cardcontainer-scale-in");
            await UniTask.Delay(TimeSpan.FromSeconds(0.3f));

            //изменение состояния карты
            Upheaval(cardContainer);

            //разворот картикой вверх
            cardContainer.RemoveFromClassList("cardcontainer-scale-in");
            cardContainer.AddToClassList("cardcontainer-scale-out");
        }

        private void Upheaval(VisualElement cardContainer)
        {
            cardContainer.Q<VisualElement>("Shirt").style.display = DisplayStyle.None;
            cardContainer.Q<VisualElement>("Front").style.display = DisplayStyle.Flex;
        }
    }
}
