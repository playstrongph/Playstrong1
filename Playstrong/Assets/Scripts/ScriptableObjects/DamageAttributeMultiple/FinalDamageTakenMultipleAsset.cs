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
            var target = TargetMultiple.GetHeroTargets(hero);
            var damageMultiple = hero.HeroLogic.TakeDamage.FinalDamage;
            return damageMultiple;
        }
        
        
        
        //Accessed by something - either basic action or status effect asset 
        public void SetCalculatedValue(IHero targetHero)
        {
            _damageMultiple = GetDamageMultiple(targetHero);
        }
        
        //Note: Accessed by DealDamageBasicAction via ICalculatedValueAsset interface
        public float GetCalculatedValue()
        {
            return _damageMultiple;
        }
       
    }
}
