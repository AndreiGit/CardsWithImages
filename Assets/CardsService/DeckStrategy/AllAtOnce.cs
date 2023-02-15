namespace CardsService.DeckStrategy
{
    public class AllAtOnce : IDeckStrategy
    {
        public string Name => Constant.AllAtOnceStrategy;

        public void LoadImages(Card[] cards)
        {

        }
    }
}
