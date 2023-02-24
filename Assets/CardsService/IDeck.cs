using CardsService.DeckStrategy;
using System;
using UnityEngine.UIElements;

namespace CardsService
{
    public interface IDeck
    {
        void SetStrategy(string strategy);

        void LoadImagesAsync(Action<bool> actionSetUIInteractable);

        void CancelLoading();
    }
}
