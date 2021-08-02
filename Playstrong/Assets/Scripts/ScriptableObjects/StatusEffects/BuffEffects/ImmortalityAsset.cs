using System.Collections;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Immortality", menuName = "SO's/Status Effects/Buffs/Immortality")]
    public class ImmortalityAsset : StatusEffectAsset
    {

        [SerializeField] private int setLife = 1;
        
        public override void ApplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EHeroTakesFatalDamage += ImmortalityEffect;
        }

        public override void UnapplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EHeroTakesFatalDamage -= ImmortalityEffect;
        }

        private void ImmortalityEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(ImmortalityEffectCoroutine(hero));
        }

        private IEnumerator ImmortalityEffectCoroutine(IHero hero)
        {
            hero.HeroLogic.SetHeroHealth.SetHealth(setLife);
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }
    }
}
