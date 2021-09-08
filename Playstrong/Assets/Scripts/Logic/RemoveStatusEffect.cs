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
            
            _thisHeroStatusEffect.StatusEffectAsset.UnapplyStatusEffect(hero);

            var heroStatusEffects = hero.HeroStatusEffects;
            
            _thisHeroStatusEffect.StatusEffectType.RemoveFromStatusEffectList(heroStatusEffects, _thisHeroStatusEffect);

            logicTree.AddCurrent(DestroyStatusEffectObject(hero));
            
            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator DestroyStatusEffectObject(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;

            var statusEffectPreview = _thisHeroStatusEffect.StatusEffectPreview;
            
            Destroy(statusEffectPreview);
            
            Destroy(this.gameObject);
            
            logicTree.EndSequence();
            yield return null;
        }


    }
}
