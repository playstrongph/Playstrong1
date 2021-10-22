using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using ScriptableObjects.StatusEffects;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DispelAllDebuffs", menuName = "SO's/BasicActions/DispelAllDebuffs")]
    
    public class DispelAllDebuffsBasicActionAsset : BasicActionAsset
    {
        public override IEnumerator TargetAction(IHero hero)
        {

            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;

            var debuffs = hero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;
            
            foreach (var debuff in debuffs)
            {
                debuff.StatusEffectDispelStatus.DispelStatusEffect(debuff,hero);
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var debuffs = targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;

            foreach (var debuff in debuffs)
            {
                debuff.StatusEffectDispelStatus.DispelStatusEffect(debuff,targetHero);
            }
            
            logicTree.EndSequence();
            yield return null;
        }


        public override IEnumerator UndoTargetAction(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //No Action
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero thisHero,IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            //No Action
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
