using System;

namespace CardsService.CardStates
{
    public interface ICardStateProvider
    {
        ICardState Current {get;}

        void AddState<T>(ICardState cardState) where T : ICardState;

        ICardState SetState<T>() where T : ICardState;
    }
}
