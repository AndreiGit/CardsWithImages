using CardsService.DeckStrategy;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CardsService
{
    public class Deck : IDeck
    {
        public Deck(VisualElement deck)
        {
            _deck = deck;

            InitDeck();
            InitStrategies();
        }


        private readonly VisualElement _deck;

        private IDeckStrategy _current;

        private IDeckStrategyProvider _strategyProvider;

        private List<Card> _cards = new(); 

        private void InitDeck()
        {
            foreach (var child in _deck.Children())
            {
                Card card = new(child);
                _cards.Add(card);
            }
        }

        public void SetStrategy(string strategy) => _current = _strategyProvider.GetStrategy(strategy);

        public async void LoadImagesAsync() => await _current.LoadImagesAsync(_cards.ToArray());

        private void InitStrategies()
        {
            _strategyProvider = new DeckStrategyProvider();

            _strategyProvider.AddStrategy(new AllAtOnce());
            _strategyProvider.AddStrategy(new OneByOne());
            _strategyProvider.AddStrategy(new WhenImageReady());
        }
    }
}
