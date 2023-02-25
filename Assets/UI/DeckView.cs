using CardsService;
using EntryPoint;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class DeckView : UIControllerBase, IDeckView
    {
        [SerializeField] private VisualTreeAsset _cardContainer;

        [SerializeField] private int _cardCount;

        public IDeck Deck { get; private set; }

        private VisualElement _container;

        protected override void Awake()
        {
            App.Instance.RegisterService<IDeckView>(this);
            base.Awake();
        }

        void Start() => Init();

        private void Init()
        {
            _container = GetElement<VisualElement>("Root");
            var deckElement = GetElementFrom<VisualElement>("Deck", _container);

            Deck = new Deck(deckElement, _cardContainer, _cardCount);
        }
    }
}
