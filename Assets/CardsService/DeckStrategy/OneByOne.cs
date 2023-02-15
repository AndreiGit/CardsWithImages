using Cysharp.Threading.Tasks;

namespace CardsService.DeckStrategy
{
    public class OneByOne : IDeckStrategy
    {
        public string Name => Constant.OneByOneStrategy;

        public async UniTask LoadImagesAsync(Card[] cards)
        {
            //foreach (var card in cards)
            //{
            //    await PlayAnimationAsync(card._cardContainer);
            //}
        }
    }
}
