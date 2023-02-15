using CardsService.CardStates;
using System.Drawing;
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

        private readonly VisualElement _image;

        private ICardState _currentState;

        public void SetTexture()
        {

        }

        private void InitCardStates()
        {
            ICardState shirtState = new Shirt(CardContainer.Q<VisualElement>("Shirt"));
            ICardState frontState = new Front(CardContainer.Q<VisualElement>("Front"));
        }
    }
}
