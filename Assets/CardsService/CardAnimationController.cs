using CardsService.CardStates;
using Cysharp.Threading.Tasks;
using System;

namespace CardsService
{
    public class CardAnimationController : ICardAnimationController
    {
        private float _duration = 0.3f;

        public async UniTask PlayAnimationAsync<T>(Card card) where T : ICardState
        {
            var currentState = card.CardStateProvider.Current;

            if (currentState.GetType() != typeof(T))
            {
                card.CardContainer.RemoveFromClassList("cardcontainer-scale-out");
                card.CardContainer.AddToClassList("cardcontainer-scale-in");
                await UniTask.Delay(TimeSpan.FromSeconds(_duration));

                card.CardStateProvider.SetState<T>();
            }

            card.CardContainer.RemoveFromClassList("cardcontainer-scale-in");
            card.CardContainer.AddToClassList("cardcontainer-scale-out");
        }
    }
}
