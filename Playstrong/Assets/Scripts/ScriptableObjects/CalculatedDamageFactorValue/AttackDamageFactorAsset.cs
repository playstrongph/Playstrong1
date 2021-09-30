using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    [CreateAssetMenu(fileName = "AttackFactor", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/AttackFactor")]
    public class AttackDamageFactorAsset : CalculatedFactorValueAsset
    {
        private int _factor;
        public override int GetDamageFactor(IHero hero)
        {
            //var target = ActionTargets.GetHeroTarget(hero);
            
            var currentAttack = hero.HeroLogic.HeroAttributes.Attack;
            
            var attackFactor = Mathf.CeilToInt(currentAttack * percentFactor / 100f);
            
            return attackFactor;
        }
        
        public override int GetDamageFactor(IHero thisHero, IHero targetHero)
        {
            //var target = ActionTargets.GetHeroTarget(thisHero,targetHero);
            
            var currentAttack = targetHero.HeroLogic.HeroAttributes.Attack;
            
            var attackFactor = Mathf.CeilToInt(currentAttack * percentFactor / 100f);
            
            return attackFactor;
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
