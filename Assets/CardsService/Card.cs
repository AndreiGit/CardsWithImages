using CardsService.CardStates;
using UnityEngine;
using UnityEngine.UIElements;

namespace CardsService
{
    public class Card
    {
        public Card(VisualElement cardContainer) 
        {
            CardContainer = cardContainer;

            _image = cardContainer.Q<VisualElement>("Front").Q<VisualElement>("Image");

            InitCardStates();
        }

        public readonly VisualElement CardContainer;

        public ICardStateProvider CardStateProvider;

        private readonly VisualElement _image;

        public void SetTexture(Texture2D texture) => _image.style.backgroundImage = texture;

        private void InitCardStates()
        {
            CardStateProvider = new CardStateProvider();

            CardStateProvider.AddState<Shirt>(new Shirt(CardContainer.Q<VisualElement>("Shirt")));
            CardStateProvider.AddState<Front>(new Front(CardContainer.Q<VisualElement>("Front")));
        }
    }
}
