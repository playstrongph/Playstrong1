using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    /// <summary>
    /// Asset used by DealDamage basic action to deal percent damage according to damage taken by the hero
    /// </summary>
    [CreateAssetMenu(fileName = "FinalDamageTaken", menuName = "SO's/Scriptable Enums/DamageAttributeMultiple/FinalDamageTaken")]
    public class DamageTakeDamageFactorAsset : CalculatedFactorValueAsset, ICalculatedValueAsset
    {
        private int _damageMultiple;
        public override int GetDamageMultiple(IHero hero)
        {
            var target = ActionTargets.GetHeroTarget(hero);
            
            var damageMultiple = target.HeroLogic.TakeDamage.FinalDamage;
            damageMultiple = Mathf.CeilToInt(damageMultiple * percentFactor / 100);
            
            return damageMultiple;
        }
        
        public override int GetDamageMultiple(IHero thisHero, IHero targetHero)
        {
            var target = ActionTargets.GetHeroTarget(thisHero,targetHero);
            var damageMultiple = target.HeroLogic.TakeDamage.FinalDamage;
            
            damageMultiple = Mathf.CeilToInt(damageMultiple * percentFactor / 100);
            return damageMultiple;
        }      
        
        
        //Accessed by DealDamage Basic Action 
        public void SetCalculatedValue(IHero hero)
        {
            _damageMultiple = GetDamageMultiple(hero);
        }
        
        public void SetCalculatedValue(IHero thisHero,IHero targetHero)
        {
            _damageMultiple = GetDamageMultiple(thisHero,targetHero);
        }
        
        //Note: Accessed by DealDamageBasicAction via ICalculatedValueAsset interface
        public float GetCalculatedValue()
        {
            return _damageMultiple;
        }
       
    }
}
