using CardsService.DeckStrategy;

namespace CardsService
{
    public interface IDeck
    {
        IDeckStrategy Current { get; }

        void SetStrategy(string strategy);

        void LoadImages();
    }
}
