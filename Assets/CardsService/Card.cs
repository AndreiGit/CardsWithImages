using CardsService;
using UnityEngine.UIElements;

namespace CardService
{
    public class Card
    {
        public Card(VisualElement cardContainer) 
        {
            _cardContainer = cardContainer;

            InitCardStates();
        }

        private readonly VisualElement _cardContainer;

        private void InitCardStates()
        {
            ICardState shirtState = new Shirt();
            ICardState frontState = new Front();
        }
    }
}
