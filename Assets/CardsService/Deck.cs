﻿using CardService;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace CardsService
{
    public class Deck
    {
        public Deck(VisualElement deck)
        {
            _deck = deck;

            InitDeck();
        }

        private readonly VisualElement _deck;

        private List<Card> _cards = new(); 

        private void InitDeck()
        {
            foreach (var child in _deck.Children())
            {
                Card card = new(child);
                _cards.Add(card);
            }
        }
    }
}