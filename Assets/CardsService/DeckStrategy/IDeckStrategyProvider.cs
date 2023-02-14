namespace CardsService.DeckStrategy
{
    public interface IDeckStrategyProvider
    {
        IDeckStrategy GetStrategy(string nameStrategy);

        void AddStrategy(IDeckStrategy strategy);
    }
}
