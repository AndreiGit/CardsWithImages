using CardsService.CardStates;
using Cysharp.Threading.Tasks;

namespace CardsService
{
    public interface ICardAnimationController
    {
        UniTask PlayAnimationAsync<T>(ICard card) where T : ICardState;
    }
}
