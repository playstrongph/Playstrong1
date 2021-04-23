namespace Interfaces
{
    public interface IHeroAttributes
    {
        int Attack { get; set; }
        int BaseAttack { get; set; }
        int Health { get; set; }
        int BaseHealth { get; set; }
        int Armor { get; set; }
        int BaseArmor { get; set; }
        int Speed { get; set; }
        int BaseSpeed { get; set; }
        int Chance { get; set; }
        int BaseChance { get; set; }
        int Energy { get; set; }
    }
}