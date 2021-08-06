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

        int HeroAssetAttack { get; set; }
        
        int HeroAssetSpeed { get; set; }
        
        int HeroAssetHealth { get; set; }
        
        int HeroAssetChance { get; set; }

        float CriticalChance { get; set; }

        float CriticalDamageMultiplier { get; set; }

        float Accuracy { get; set; }

        float Resistance { get; set; }

        float TotalDamageReduction { get; set; }

        float CriticalDamageReduction { get; set; }


    }
}