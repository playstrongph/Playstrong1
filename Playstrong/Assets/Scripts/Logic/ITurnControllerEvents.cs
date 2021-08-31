using System.Collections;

namespace Logic
{
    public interface ITurnControllerEvents
    {
        IEnumerator GameStartEvent();
        event TurnControllerEvents.TurnControlEvent EStartCombatTurn;
        event TurnControllerEvents.TurnControlEvent EEndCombatTurn;
        void EndCombatTurn();
        void StartCombatTurn();


    }
}