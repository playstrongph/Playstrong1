using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseCalculatedPassiveAttack", menuName = "SO's/BasicActions/D/DecreaseCalculatedPassiveAttack")]
    
    public class DecreaseCalculatedPassiveAttackBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int flatAttack;
        [SerializeField] private int percentAttack;

        [SerializeField] private ScriptableObject calculatedValue;
        private ICalculatedFactorValueAsset CalculatedValue => calculatedValue as ICalculatedFactorValueAsset;

        private int _changeAttackValue;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            SetChangeAttackValue(targetHero);
            
            targetHero.HeroLogic.PassiveSkillHeroAttributes.Attack -= _changeAttackValue;
            
            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack - _changeAttackValue;
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            SetChangeAttackValue(targetHero);

            targetHero.HeroLogic.PassiveSkillHeroAttributes.Attack -= _changeAttackValue;
            
            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack - _changeAttackValue;
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        /*public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            targetHero.HeroLogic.PassiveSkillHeroAttributes.Attack += _changeAttackValue;
            
            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack + _changeAttackValue;
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            targetHero.HeroLogic.PassiveSkillHeroAttributes.Attack += _changeAttackValue;
            
            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack + _changeAttackValue;
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }*/


        private void SetChangeAttackValue(IHero hero)
        {
            _changeAttackValue = 0;
            
            var baseAttack = hero.HeroLogic.HeroAttributes.BaseAttack;
            _changeAttackValue = Mathf.FloorToInt(baseAttack * percentAttack/100) + flatAttack 
                + (int)CalculatedValue.GetCalculatedValue();
        }

      










    }
}
