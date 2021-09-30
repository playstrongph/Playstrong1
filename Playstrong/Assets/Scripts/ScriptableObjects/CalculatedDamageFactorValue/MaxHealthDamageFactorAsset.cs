using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    [CreateAssetMenu(fileName = "MaxHealth", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/MaxHealth")]
    public class MaxHealthDamageFactorAsset : CalculatedFactorValueAsset
    {
        private int _factor;
        public override int GetDamageFactor(IHero hero)
        {
            var target = ActionTargets.GetHeroTarget(hero);
            
            var maxHealthFactor = target.HeroLogic.HeroAttributes.BaseHealth;
            maxHealthFactor = Mathf.CeilToInt(maxHealthFactor * percentFactor / 100);
            
            return maxHealthFactor;
        }
        
        public override int GetDamageFactor(IHero thisHero, IHero targetHero)
        {
            var target = ActionTargets.GetHeroTarget(thisHero,targetHero);
            var maxHealthFactor = target.HeroLogic.HeroAttributes.BaseHealth;
            maxHealthFactor = Mathf.CeilToInt(maxHealthFactor * percentFactor / 100);
            return maxHealthFactor;
        }      
        
        
        //Accessed by DealDamage Basic Action 
        public override void SetCalculatedValue(IHero hero)
        {
            _factor = GetDamageFactor(hero);
        }
        
        public override void SetCalculatedValue(IHero thisHero,IHero targetHero)
        {
            _factor = GetDamageFactor(thisHero,targetHero);
        }
        
        //Note: Accessed by DealDamageBasicAction via ICalculatedValueAsset interface
        public override float GetCalculatedValue()
        {
            return _factor;
        }
       
    }
}
