using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    /// <summary>
    /// Asset used by DealDamage basic action to deal percent damage according to damage taken by the hero
    /// </summary>
    [CreateAssetMenu(fileName = "ZeroDamage", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/ZeroDamage")]
    public class ZeroDamageMultipleAsset : CalculatedFactorValueAsset
    {
        private int _damageMultiple;
        /*public override int DamageFactorBasis(IHero hero)
        {
            var damageMultiple = 0;
            
            return damageMultiple;
        }
        
        public override int DamageFactorBasis(IHero thisHero, IHero targetHero)
        {
            //var target = ActionTargets.GetHeroTarget(thisHero,targetHero);
            
            var damageMultiple = targetHero.HeroLogic.TakeDamage.FinalDamage;
            
            damageMultiple = Mathf.CeilToInt(damageMultiple * percentFactor / 100f);
            return damageMultiple;
        }      
        
        
        //Accessed by DealDamage Basic Action 
        public override void SetCalculatedValue(IHero hero)
        {
            _damageMultiple = DamageFactorBasis(hero);
        }
        
        public override void SetCalculatedValue(IHero thisHero,IHero targetHero)
        {
            _damageMultiple = DamageFactorBasis(thisHero,targetHero);
        }*/
        
        //Note: Accessed by DealDamageBasicAction via ICalculatedValueAsset interface
        public override float GetCalculatedValue()
        {
            var damageFactor = 0;
            return damageFactor;
        }
       
    }
}
