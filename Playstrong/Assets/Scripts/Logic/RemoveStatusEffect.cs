using System;
using System.Collections;
using Interfaces;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Object = System.Object;

namespace Logic
{
    public class RemoveStatusEffect : MonoBehaviour
    {
        private IHeroStatusEffect _thisHeroStatusEffect;

        private void Awake()
        {
            _thisHeroStatusEffect = GetComponent<IHeroStatusEffect>();
        }


        public void RemoveEffect()
        {
          
           
           
        }

        public IEnumerator RemoveEffectCoroutine(IHero hero, IStatusEffectAsset statusEffectAsset)
        {
            _thisHeroStatusEffect.StatusEffectAsset.UnapplyStatusEffect();

            var bufflist = hero.HeroStatusEffects.HeroBuffEffects;
            var debuffList = hero.HeroStatusEffects.HeroDebuffEffects;
            var thisHeroStatusEffectObject = _thisHeroStatusEffect as UnityEngine.Object;

            bufflist.HeroBuffs.Remove(_thisHeroStatusEffect);
            bufflist.HeroBuffObjects.Remove(thisHeroStatusEffectObject);

            debuffList.HeroDebuffs.Remove(_thisHeroStatusEffect);
            debuffList.HeroDebuffObjects.Remove(thisHeroStatusEffectObject);
            
            Destroy(this.gameObject);

            yield return null;
        }


    }
}
