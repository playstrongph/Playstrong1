using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.DamageAttributeMultiple;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "CurseTest", menuName = "SO's/Status Effects/Debuffs/CurseTest")]
    public class CurseAssetTest : StatusEffectAsset
    {
        [SerializeField] private ScriptableObject damageFactor;
        private ICalculatedFactorValueAsset DamageFactor  => damageFactor as ICalculatedFactorValueAsset;
        
        public override void ApplyStatusEffect(IHero hero)
        {
            foreach (var allyHero in hero.AllAllyHeroes)
            {
                //TODO: Test only, transfer this to a basic action
                //DamageFactor.SetHeroBasis(allyHero);
                
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
