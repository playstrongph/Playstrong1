 using System.Collections;
using System.Runtime.CompilerServices;
using Interfaces;
using Logic;
 using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Recovery", menuName = "SO's/Status Effects/Buffs/Recovery")]
    public class RecoveryAsset : StatusEffectAsset
    {
        public override void ApplyStatusEffect(IHero hero)
        { 
            //hero.HeroLogic.HeroEvents.EPreHeroStartTurn += RecoveryEffect;
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(StandardAction.RegisterStandardAction(hero));
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            //hero.HeroLogic.HeroEvents.EPreHeroStartTurn -= RecoveryEffect;
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(StandardAction.UnregisterStandardAction(hero));
        }

        private void RecoveryEffect(IHero hero)
        {
            //var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            //logicTree.AddCurrent(RecoveryEffectCoroutine(hero));
            //StandardAction.StartAction(hero);
        }


        private IEnumerator RecoveryEffectCoroutine(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero,hero));

            logicTree.EndSequence();
            yield return null;
        }
        
       


















    }
}
