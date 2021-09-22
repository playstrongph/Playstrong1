using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    [CreateAssetMenu(fileName = "FinalDamageTaken", menuName = "SO's/Scriptable Enums/DamageAttributeMultiple/FinalDamageTaken")]
    public class FinalDamageTakenMultipleAsset : DamageAttributeMultipleAsset, ICalculatedValueAsset
    {
        private int _damageMultiple;
        public override int GetDamageMultiple(IHero hero)
        {
            var target = TargetMultiple.GetHeroTarget(hero);
            
            var damageMultiple = target.HeroLogic.TakeDamage.FinalDamage;
            damageMultiple = Mathf.CeilToInt(damageMultiple * percentFactor / 100);
            
            return damageMultiple;
        }
        
        public override int GetDamageMultiple(IHero thisHero, IHero targetHero)
        {
            var target = TargetMultiple.GetHeroTarget(thisHero,targetHero);
            var damageMultiple = target.HeroLogic.TakeDamage.FinalDamage;
            
            damageMultiple = Mathf.CeilToInt(damageMultiple * percentFactor / 100);
            return damageMultiple;
        }
        
        
        
        //Accessed by something - either basic action or status effect asset 
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
