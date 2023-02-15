using CardsService.CardStates;
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
                //������������ ��������
                await PlayAnimationAsync(card);

                //���������� �������� � �����

                //��������� ��������
            });

            //������������� ������� �������� �����
            await UniTask.WhenAll(cardsFlipBack);

            //������������� ������� �������� �����
        }

        private async UniTask PlayAnimationAsync(Card card)
        {
            //��������� �������� ����
            card.CardContainer.RemoveFromClassList("cardcontainer-scale-out");
            card.CardContainer.AddToClassList("cardcontainer-scale-in");
            await UniTask.Delay(TimeSpan.FromSeconds(0.3f));

            //��������� ��������� �����
            card.CardStateProvider.SetState<Front>();
            Upheaval(card.CardContainer);

            //�������� �������� �����
            card.CardContainer.RemoveFromClassList("cardcontainer-scale-in");
            card.CardContainer.AddToClassList("cardcontainer-scale-out");
        }

        private void Upheaval(VisualElement cardContainer)
        {
            cardContainer.Q<VisualElement>("Shirt").style.display = DisplayStyle.None;
            cardContainer.Q<VisualElement>("Front").style.display = DisplayStyle.Flex;
        }
    }
}
