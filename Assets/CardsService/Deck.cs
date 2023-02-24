using CardsService.DeckStrategy;
using System;
using System.Collections.Generic;
using System.Threading;
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

        private List<ICard> _cards = new(); 

        private CancellationTokenSource _tokenSource;

        private void InitDeck()
        {
            foreach (var child in _deck.Children())
            {
                Card card = new(child);
                _cards.Add(card);
            }
        }

        public void SetStrategy(string strategy) => _current = _strategyProvider.GetStrategy(strategy);

        public async void LoadImagesAsync(Action<bool> actionSetUIInteractable)
        {
            try
            {
                actionSetUIInteractable?.Invoke(false);
                _tokenSource = new CancellationTokenSource();

                await _current.LoadImagesAsync(_cards.ToArray(), _tokenSource.Token)
                    .SuppressCancellationThrow();
            }
            finally
            {
                _tokenSource.Dispose();
                _tokenSource = null;
                actionSetUIInteractable?.Invoke(true);
            }
        }

        public void CancelLoading()
        {
            if (_tokenSource is not null)
            {
                _tokenSource.Cancel();
            }
        }

        private void InitStrategies()
        {
            _strategyProvider = new DeckStrategyProvider();

            _strategyProvider.AddStrategy(new AllAtOnce());
            _strategyProvider.AddStrategy(new OneByOne());
            _strategyProvider.AddStrategy(new WhenImageReady());
        }
    }
}
