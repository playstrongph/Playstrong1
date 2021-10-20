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
    [CreateAssetMenu(fileName = "DispelSpecificDebuff", menuName = "SO's/BasicActions/DispelSpecificDebuff")]
    
    public class DispelSpecificDebuffBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private ScriptableObject _specificDebuff;
        private IStatusEffectAsset SpecificDebuff => _specificDebuff as IStatusEffectAsset;

        private IHeroStatusEffect _dispelDebuff;

        public override IEnumerator TargetAction(IHero hero)
        {

            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;

            var debuffs = hero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;
            
            foreach (var debuff in debuffs)
            {
                if (debuff.StatusEffectAsset.Name == SpecificDebuff.Name)
                    _dispelDebuff = debuff;
            }
            
            //Only dispels 1 debuff in case there are multiple instances (e.g. burn, poison)
            if(_dispelDebuff != null)
                _dispelDebuff.StatusEffectDispelStatus.DispelStatusEffect(_dispelDebuff,hero);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var debuffs = targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;

            foreach (var debuff in debuffs)
            {
                if (debuff.StatusEffectAsset.Name == SpecificDebuff.Name)
                    _dispelDebuff = debuff;
            }
            
            //Only dispels 1 debuff in case there are multiple instances (e.g. burn, poison)
            if(_dispelDebuff != null)
                _dispelDebuff.StatusEffectDispelStatus.DispelStatusEffect(_dispelDebuff,targetHero);
            
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
