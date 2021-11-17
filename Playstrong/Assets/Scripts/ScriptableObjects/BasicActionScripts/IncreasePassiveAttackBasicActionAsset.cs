using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreasePassiveAttackBasicAction", menuName = "SO's/BasicActions/I/IncreasePassiveAttackBasicAction")]
    
    public class IncreasePassiveAttackBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int flatAttack;
        [SerializeField] private int percentAttack;

        private int _changeAttackValue;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            SetChangeAttackValue(targetHero);

            targetHero.HeroLogic.PassiveSkillHeroAttributes.Attack += _changeAttackValue;
            
            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack + _changeAttackValue;
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            SetChangeAttackValue(targetHero);

            targetHero.HeroLogic.PassiveSkillHeroAttributes.Attack += _changeAttackValue;
            
            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack + _changeAttackValue;
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        /*public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            
            Debug.Log("Increase Attack UndoTargetAction1: "+targetHero.HeroName);
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.Attack -= _changeAttackValue;
            
            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack - _changeAttackValue;
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero thisHero, IHero targetHero)
        {
            Debug.Log("Increase Attack UndoTargetAction2: "+targetHero.HeroName);
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            targetHero.HeroLogic.PassiveSkillHeroAttributes.Attack -= _changeAttackValue;
            
            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack - _changeAttackValue;
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }*/


        private void SetChangeAttackValue(IHero hero)
        {
            _changeAttackValue = 0;
            
            var baseAttack = hero.HeroLogic.HeroAttributes.BaseAttack;
            _changeAttackValue = Mathf.FloorToInt(baseAttack * percentAttack/100) + flatAttack;
        }

      










    }
}
