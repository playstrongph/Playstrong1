using System;
using System.Collections;
using Interfaces;
using ScriptableObjects.StatusEffects;
using UnityEngine;

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
           _thisHeroStatusEffect.StatusEffectAsset.UnapplyStatusEffect();
           
           
        }

        public IEnumerator RemoveEffectCoroutine(IHero hero, IStatusEffectAsset statusEffectAsset)
        {
            

            yield return null;
        }


    }
}
