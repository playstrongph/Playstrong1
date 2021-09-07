namespace Logic
{
    public interface ISetHeroEnergy
    {
        void SetEnergy(int value);

        void IncreaseEnergy(int value);

        void DecreaseEnergy(int value);
    }
}