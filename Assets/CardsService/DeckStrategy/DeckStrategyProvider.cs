using System.Collections.Generic;

namespace CardsService.DeckStrategy
{
    public class DeckStrategyProvider : IDeckStrategyProvider
    {
        private Dictionary<string, IDeckStrategy> _strategies = new();

        public IDeckStrategy GetStrategy(string nameStrategy)
        {
            return _strategies[nameStrategy];
        }

        public void AddStrategy(IDeckStrategy strategy) => _strategies[strategy.Name] = strategy;
    }
}
