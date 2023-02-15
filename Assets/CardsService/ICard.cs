using CardsService.CardStates;
using UnityEngine;
using UnityEngine.UIElements;

namespace CardsService
{
    public interface ICard
    {
        VisualElement CardContainer { get; }

        ICardStateProvider CardStateProvider { get; }

        void SetTexture(Texture2D texture);
    }
}
