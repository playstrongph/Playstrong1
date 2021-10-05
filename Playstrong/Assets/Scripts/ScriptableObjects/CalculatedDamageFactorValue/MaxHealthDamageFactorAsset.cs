﻿using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    [CreateAssetMenu(fileName = "MaxHealthFactor", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/MaxHealthFactor")]
    public class MaxHealthDamageFactorAsset : CalculatedFactorValueAsset
    {
        /*
        private int _factor;
        public override int DamageFactorBasis(IHero hero)
        {
            //var target = ActionTargets.GetHeroTarget(hero);
            
            var baseHealth = hero.HeroLogic.HeroAttributes.BaseHealth;
            var maxHealthFactor = Mathf.CeilToInt(baseHealth * percentFactor / 100f);
            
            return maxHealthFactor;
        }
        
        public override int DamageFactorBasis(IHero thisHero, IHero targetHero)
        {
            //var target = ActionTargets.GetHeroTarget(thisHero,targetHero);

            var maxHealthFactor = Mathf.CeilToInt(targetHero.HeroLogic.HeroAttributes.BaseHealth * percentFactor / 100f);
            return maxHealthFactor;
        }      
        
        
        //Accessed by DealDamage Basic Action 
        public override void SetCalculatedValue(IHero hero)
        {
            _factor = DamageFactorBasis(hero);
        }
        
        public override void SetCalculatedValue(IHero thisHero,IHero targetHero)
        {
            _factor = DamageFactorBasis(thisHero,targetHero);
        }
        */
        
        
        public override float GetCalculatedValue()
        {
            var damageFactor = 0;
            
            //Damage Taken Factor
            if (OtherHeroBasis != null)
                damageFactor = Mathf.CeilToInt(OtherHeroBasis.HeroLogic.HeroAttributes.BaseHealth * percentFactor / 100f);

            return damageFactor;
        }
       
    }
}
