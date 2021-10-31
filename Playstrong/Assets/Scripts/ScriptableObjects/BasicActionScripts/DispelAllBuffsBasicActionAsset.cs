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
    [CreateAssetMenu(fileName = "DispelAllBuffs", menuName = "SO's/BasicActions/DispelAllBuffs")]
    
    public class DispelAllBuffsBasicActionAsset : BasicActionAsset
    {
        public override IEnumerator TargetAction(IHero hero)
        {

            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;

            var buffs = hero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            
            foreach (var buff in buffs)
            {
                buff.StatusEffectDispelStatus.DispelStatusEffect(buff,hero);
                Debug.Log("buff: " + buff.Name);
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var buffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            
            foreach (var buff in buffs)
            {
                buff.StatusEffectDispelStatus.DispelStatusEffect(buff,targetHero);
                Debug.Log("buff: " + buff.Name);
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
