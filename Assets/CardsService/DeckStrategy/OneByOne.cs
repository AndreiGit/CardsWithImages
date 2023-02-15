namespace CardsService.DeckStrategy
{
    public class OneByOne : IDeckStrategy
    {
        public string Name => Constant.OneByOneStrategy;

        public void LoadImages(Card[] cards)
        {

        }
    }
}
