using System.Collections;
using Interfaces;

namespace Logic
{
    public interface ITurnControllerEvents
    {
        IEnumerator GameStartEvent();
        event TurnControllerEvents.TurnControlEvent EStartCombatTurn;
        event TurnControllerEvents.TurnControlEvent EEndCombatTurn;
        void EndCombatTurn(IHero hero);
        void StartCombatTurn(IHero hero);


    }
}