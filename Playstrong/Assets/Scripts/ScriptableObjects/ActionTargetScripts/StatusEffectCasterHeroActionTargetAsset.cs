using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargets
{
    
    [CreateAssetMenu(fileName = "StatusEffectCasterHero", menuName = "SO's/ActionTargets/StatusEffectCasterHero")]
    public class StatusEffectCasterHeroActionTargetAsset : ActionTargetsAsset
    {
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            var heroTargets = new List<IHero>();
            
            heroTargets.Clear();
            heroTargets.Add(StatusEffectLocalHero);
            
            return heroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero hero)
        {
            var heroTargets = new List<IHero>();
            heroTargets.Clear();
            
            heroTargets.Add(StatusEffectLocalHero);
            
            return heroTargets;
        }
        
        public override IHero GetHeroTarget(IHero thisHero, IHero targetHero)
        {
            return StatusEffectLocalHero;
        }
        
        public override IHero GetHeroTarget(IHero hero)
        {
            return StatusEffectLocalHero;
        }
        
        //Called by LoadStatusEffectValues
        public override IHero SetStatusEffectHero(IHeroStatusEffect heroStatusEffect)
        {
            StatusEffectLocalHero = heroStatusEffect.StatusEffectCasterHero;
            return StatusEffectLocalHero;
        }
            
    }
}
