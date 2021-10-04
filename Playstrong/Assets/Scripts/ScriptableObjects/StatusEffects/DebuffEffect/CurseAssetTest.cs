using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "CurseTest", menuName = "SO's/Status Effects/Debuffs/CurseTest")]
    public class CurseAssetTest : StatusEffectAsset
    {
        public override void ApplyStatusEffect(IHero hero)
        {
            foreach (var allyHero in hero.AllAllyHeroes)
            {
                base.ApplyStatusEffect(allyHero);   
            }
            //base.ApplyStatusEffect(hero);   
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            foreach (var allyHero in hero.AllAllyHeroes)
            {
                base.UnapplyStatusEffect(allyHero);   
            }
            //base.UnapplyStatusEffect(hero);   
        }

    }
}
