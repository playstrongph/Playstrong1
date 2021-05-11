namespace Logic
{
    public interface IEndTurnButton
    {
        ITurnController TurnController { set; }
        void EndTurn();
    }
}