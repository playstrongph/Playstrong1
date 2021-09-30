using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    /// <summary>
    /// Asset used by DealDamage basic action to deal percent damage according to damage taken by the hero
    /// </summary>
    [CreateAssetMenu(fileName = "FinalDamageTaken", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/FinalDamageTaken")]
    public class DamageTakeDamageFactorAsset : CalculatedFactorValueAsset
    {
        private int _damageMultiple;
        public override int GetDamageFactor(IHero hero)
        {
            //var target = ActionTargets.GetHeroTarget(hero);
            
            var damageFactor = hero.HeroLogic.TakeDamage.FinalDamage;
            damageFactor = Mathf.CeilToInt(damageFactor * percentFactor / 100f);
            
            return damageFactor;
        }
        
        public override int GetDamageFactor(IHero thisHero, IHero targetHero)
        {
            //var target = ActionTargets.GetHeroTarget(thisHero,targetHero);
            
            var damageFactor = targetHero.HeroLogic.TakeDamage.FinalDamage;
            
            damageFactor = Mathf.CeilToInt(damageFactor * percentFactor / 100f);
            return damageFactor;
        }      
        
        
        //Accessed by DealDamage Basic Action 
        public override void SetCalculatedValue(IHero hero)
        {
            _damageMultiple = GetDamageFactor(hero);
        }
        
        public override void SetCalculatedValue(IHero thisHero,IHero targetHero)
        {
            _damageMultiple = GetDamageFactor(thisHero,targetHero);
        }
        
        //Note: Accessed by DealDamageBasicAction via ICalculatedValueAsset interface
        public override float GetCalculatedValue()
        {
            return _damageMultiple;
        }
       
    }
}
