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
            //hero.HeroLogic.HeroEvents.EHeroTakesFatalDamage += ImmortalityEffect;
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(StandardAction.RegisterStandardAction(hero));
        }

        public override void UnapplyStatusEffect(IHero hero)
        {
            //hero.HeroLogic.HeroEvents.EHeroTakesFatalDamage -= ImmortalityEffect;
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(StandardAction.UnregisterStandardAction(hero));
        }

        private void ImmortalityEffect(IHero hero)
        {
            //var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            //logicTree.AddCurrent(ImmortalityEffectCoroutine(hero));
            //StandardAction.StartAction(hero);
        }

        private IEnumerator ImmortalityEffectCoroutine(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, setLife));
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
