using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Resurrect", menuName = "SO's/Status Effects/Buffs/Resurrect")]
    public class ResurrectAsset : StatusEffectAsset
    {
        [SerializeField]
        private float resurrectChance = 100f;

        public override void ApplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.OtherAttributes.ResurrectChance += resurrectChance;
            base.ApplyStatusEffect(hero);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.OtherAttributes.ResurrectChance -= resurrectChance;
            base.UnapplyStatusEffect(hero);
        }

        public override void RemoveStatusEffectOnDeath(IHero hero,IHeroStatusEffect heroStatusEffect)
        {
           //Don't destroy Resurrect upon death
        }

       
        
        










    }
}
