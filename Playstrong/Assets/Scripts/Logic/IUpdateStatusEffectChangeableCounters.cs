namespace Logic
{
    public interface IUpdateStatusEffectChangeableCounters
    {
        void SetToChangeableCounters( );
        void SetToNotChangeableCounters( );
        void SetToTempNoDecreaseCounters( );
    }
}