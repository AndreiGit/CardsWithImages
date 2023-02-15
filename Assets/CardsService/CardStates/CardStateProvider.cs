using System;
using System.Collections.Generic;

namespace CardsService.CardStates
{
    public class CardStateProvider : ICardStateProvider
    {
        public ICardState Current { get; private set; }

        private Dictionary<Type, ICardState> _states = new();

        public void AddState<T>(ICardState cardState) where T : ICardState => _states[typeof(T)] = cardState;

        public ICardState SetState<T>() where T : ICardState
        {
            Current?.Uninstall();
            Current = _states[typeof(T)];
            Current.Install();
            return Current;
        }
    }
}
