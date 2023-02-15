using UnityEngine.UIElements;

namespace CardsService.CardStates
{
    public class Front : ICardState
    {
        public Front(VisualElement side) => _side = side;

        private readonly VisualElement _side;

        public void Install()
        {
            _side.style.display = DisplayStyle.Flex;
        }

        public void Uninstall()
        {
            _side.style.display = DisplayStyle.None;
        }
    }
}
