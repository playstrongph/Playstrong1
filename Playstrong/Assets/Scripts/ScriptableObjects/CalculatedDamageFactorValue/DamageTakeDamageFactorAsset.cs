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
        
        //Accessed by DealDamage Basic Action 
        public override void SetCalculatedValue(IHero hero)
        {
            _damageMultiple = DamageFactorBasis(hero);
        }
        
        public override void SetCalculatedValue(IHero thisHero,IHero targetHero)
        {
            targetHero = SetTargetHeroBasis(thisHero, targetHero);
            _damageMultiple = DamageFactorBasis(thisHero,targetHero);
        }


        public override int DamageFactorBasis(IHero hero)
        {
            //var target = ActionTargets.GetHeroTarget(hero);
            
            var damageFactor = hero.HeroLogic.TakeDamage.FinalDamage;
            damageFactor = Mathf.CeilToInt(damageFactor * percentFactor / 100f);
            
            Debug.Log("Hero Damage Basis: " +hero +" Damage: " +damageFactor);
            
            return damageFactor;
        }
        
        public override int DamageFactorBasis(IHero thisHero, IHero targetHero)
        {
            //var target = ActionTargets.GetHeroTarget(thisHero,targetHero);
            
            var damageFactor = targetHero.HeroLogic.TakeDamage.FinalDamage;
            
            damageFactor = Mathf.CeilToInt(damageFactor * percentFactor / 100f);
            
            Debug.Log("TargetHero Damage Basis: " +targetHero +" Damage: " +damageFactor);
            
            return damageFactor;
        }

        //Note: Accessed by DealDamageBasicAction via ICalculatedValueAsset interface
        public override float GetCalculatedValue()
        {
            return _damageMultiple;
        }
        
        //TEST
        public override float GetCalculatedValue(IHero hero)
        {
            //if successful change this to return a float
            SetCalculatedValue(hero);
            return _damageMultiple;
        }
        
        public override float GetCalculatedValue(IHero thisHero,IHero targetHero)
        {
            //if successful change this to return a float
            SetCalculatedValue(thisHero,targetHero);
            return _damageMultiple;
        }
        
        
       
    }
}
