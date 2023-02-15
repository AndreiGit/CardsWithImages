namespace CardsService.DeckStrategy
{
    public interface IDeckStrategy
    {
        public string Name { get; }

        public void LoadImages(Card[] cards);
    }
}
