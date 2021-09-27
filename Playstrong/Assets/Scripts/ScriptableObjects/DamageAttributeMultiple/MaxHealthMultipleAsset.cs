using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    [CreateAssetMenu(fileName = "MaxHealth", menuName = "SO's/Scriptable Enums/DamageAttributeMultiple/MaxHealth")]
    public class MaxHealthMultipleAsset : DamageAttributeMultipleAsset, ICalculatedValueAsset
    {
        private int _multiple;
        public override int GetDamageMultiple(IHero hero)
        {
            var target = ActionTargets.GetHeroTarget(hero);
            
            var maxHealthMultiple = target.HeroLogic.HeroAttributes.BaseHealth;
            maxHealthMultiple = Mathf.CeilToInt(maxHealthMultiple * percentFactor / 100);
            
            return maxHealthMultiple;
        }
        
        public override int GetDamageMultiple(IHero thisHero, IHero targetHero)
        {
            var target = ActionTargets.GetHeroTarget(thisHero,targetHero);
            var maxHealthMultiple = target.HeroLogic.HeroAttributes.BaseHealth;
            maxHealthMultiple = Mathf.CeilToInt(maxHealthMultiple * percentFactor / 100);
            return maxHealthMultiple;
        }      
        
        
        //Accessed by DealDamage Basic Action 
        public void SetCalculatedValue(IHero hero)
        {
            _multiple = GetDamageMultiple(hero);
        }
        
        public void SetCalculatedValue(IHero thisHero,IHero targetHero)
        {
            _multiple = GetDamageMultiple(thisHero,targetHero);
        }
        
        //Note: Accessed by DealDamageBasicAction via ICalculatedValueAsset interface
        public float GetCalculatedValue()
        {
            return _multiple;
        }
       
    }
}
