using System;
using System.Collections;
using Interfaces;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Object = System.Object;

namespace Logic
{
    public class RemoveStatusEffect : MonoBehaviour, IRemoveStatusEffect
    {
        private IHeroStatusEffect _thisHeroStatusEffect;

        private void Awake()
        {
            _thisHeroStatusEffect = GetComponent<IHeroStatusEffect>();
        }


        public void RemoveEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(RemoveEffectCoroutine(hero));
        }

        private IEnumerator RemoveEffectCoroutine(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            _thisHeroStatusEffect.StatusEffectAsset.UnapplyStatusEffect();

            var buffList = hero.HeroStatusEffects.HeroBuffEffects;
            var debuffList = hero.HeroStatusEffects.HeroDebuffEffects;
            var thisHeroStatusEffectObject = _thisHeroStatusEffect as UnityEngine.Object;

            buffList.HeroBuffs.Remove(_thisHeroStatusEffect);
            buffList.HeroBuffObjects.Remove(thisHeroStatusEffectObject);

            debuffList.HeroDebuffs.Remove(_thisHeroStatusEffect);
            debuffList.HeroDebuffObjects.Remove(thisHeroStatusEffectObject);
            
            Destroy(this.gameObject);
            
            logicTree.EndSequence();
            yield return null;
        }


    }
}
