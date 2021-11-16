using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseAttack", menuName = "SO's/BasicActions/D/DecreaseAttack")]
    
    public class DecreaseAttackBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int flatAttack;
        [SerializeField] private int percentAttack;

        [SerializeField] private ScriptableObject calculatedValue;
        private ICalculatedFactorValueAsset CalculatedValue => calculatedValue as ICalculatedFactorValueAsset;

        private int changeAttackValue;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            SetChangeAttackValue(targetHero);

            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack - changeAttackValue;
            
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            SetChangeAttackValue(targetHero);

            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack - changeAttackValue;
            
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack + changeAttackValue;
            
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack + changeAttackValue;
            
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }


        private void SetChangeAttackValue(IHero hero)
        {
            changeAttackValue = 0;
            
            var baseAttack = hero.HeroLogic.HeroAttributes.BaseAttack;
            changeAttackValue = Mathf.FloorToInt(baseAttack * percentAttack/100) + flatAttack 
                + (int)CalculatedValue.GetCalculatedValue();
        }

      










    }
}
