using CardsService.CardStates;
using UnityEngine.UIElements;

namespace CardsService
{
    public class Card
    {
        public Card(VisualElement cardContainer) 
        {
            _cardContainer = cardContainer;

            InitCardStates();
        }

        private readonly VisualElement _cardContainer;

        private ICardState _currentState;

        private void InitCardStates()
        {
            ICardState shirtState = new Shirt();
            ICardState frontState = new Front();
        }
    }
}
