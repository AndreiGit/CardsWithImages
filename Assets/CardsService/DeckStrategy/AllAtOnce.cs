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
                //������������ ��������
                await PlayAnimationAsync(card);

                //���������� �������� � �����
                var texture = await _HTTPController.GetTextureAsync();

                //��������� ��������
                card.SetTexture(texture);
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

            //�������� �������� �����
            card.CardContainer.RemoveFromClassList("cardcontainer-scale-in");
            card.CardContainer.AddToClassList("cardcontainer-scale-out");
        }
    }
}
