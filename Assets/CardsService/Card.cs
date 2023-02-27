using CardsService.CardStates;
using UnityEngine;
using UnityEngine.UIElements;

namespace CardsService
{
    public class Card : ICard
    {
        public Card(VisualElement cardContainer) 
        {
            CardContainer = cardContainer;

            _image = cardContainer.Q<VisualElement>(Constant.Front)
                .Q<VisualElement>(Constant.Image);

            InitCardStates();
        }

        public VisualElement CardContainer { get; private set; }

        public ICardStateProvider CardStateProvider { get; private set; }

        private readonly VisualElement _image;

        public void SetTexture(Texture2D texture)
        {
            Texture2D.Destroy(_image.style.backgroundImage.value.texture);
            _image.style.backgroundImage = texture;
        }

        private void InitCardStates()
        {
            CardStateProvider = new CardStateProvider();

            CardStateProvider.AddState<Shirt>(new Shirt(CardContainer.Q<VisualElement>(Constant.Shirt)));
            CardStateProvider.AddState<Front>(new Front(CardContainer.Q<VisualElement>(Constant.Front)));
            CardStateProvider.SetState<Shirt>();
        }
    }
}
