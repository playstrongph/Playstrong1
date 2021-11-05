using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    /// <summary>
    /// Returns the amount of fighting spirit a hero has
    /// </summary>
    [CreateAssetMenu(fileName = "FightingSpiritFactor", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/FightingSpiritFactor")]
    public class FightingSpiritCalculatedFactorAsset : CalculatedFactorValueAsset
    {
        public override float GetCalculatedValue(IHero targetHero)
        {
            var fightingSpirit = 0;
            
            if (targetHero != null)
                fightingSpirit = targetHero.HeroLogic.OtherAttributes.FightingSpirit;

            return fightingSpirit;
        }
        
        public override float GetCalculatedValue(IHero thisHero, IHero targetHero)
        {
            var fightingSpirit = 0;
            
            if (targetHero != null)
                fightingSpirit = targetHero.HeroLogic.OtherAttributes.FightingSpirit;

            return fightingSpirit;
        }
       
    }
}
