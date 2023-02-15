using CardsService.DeckStrategy;

namespace CardsService
{
    public interface IDeck
    {
        void SetStrategy(string strategy);

        void LoadImagesAsync();

        void CancelLoading();
    }
}
