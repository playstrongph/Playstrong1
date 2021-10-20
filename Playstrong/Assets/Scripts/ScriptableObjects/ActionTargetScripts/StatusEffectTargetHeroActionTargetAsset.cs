using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargets
{
    
    [CreateAssetMenu(fileName = "StatusEffectTargetHero", menuName = "SO's/ActionTargets/StatusEffectTargetHero")]
    public class StatusEffectTargetHeroActionTargetAsset : ActionTargetsAsset
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
        
        //Called by ApplyStatusEffect
        public override IHero SetStatusEffectHero(IHeroStatusEffect heroStatusEffect)
        {
            StatusEffectLocalHero = heroStatusEffect.StatusEffectTargetHero;
            return StatusEffectLocalHero;
        }
            
    }
}
