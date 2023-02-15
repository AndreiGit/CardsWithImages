namespace CardsService.DeckStrategy
{
    public class WhenImageReady : IDeckStrategy
    {
        public string Name => Constant.WhenImageReadyStrategy;

        public void LoadImages(Card[] cards)
        {

        }
    }
}
