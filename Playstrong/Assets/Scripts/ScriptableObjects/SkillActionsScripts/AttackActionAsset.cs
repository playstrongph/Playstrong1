using System.Collections;
using Interfaces;
using ScriptableObjects.AnimationSOscripts;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "AttackActionAsset", menuName = "SO's/SkillActions/AttackActionAsset")]
    
    public class AttackActionAsset : SkillActionAsset
    {
        [Header("Game Animation Asset")]
        [SerializeField] private ScriptableObject attackAnimation;
        private IGameAnimations AttackAnimation => attackAnimation as IGameAnimations;

        private int _finalAttackValue;
        private float _intervalDelay = 0.7f;

        [Header("Attack Target Type")] [SerializeField]
        private ScriptableObject attackTargetType;
        private ISingleOrMultiAttackTypeAsset AttackTargetType => attackTargetType as ISingleOrMultiAttackTypeAsset;
        

        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
           Debug.Log("Attack Action");
            
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(AttackHero(thisHero,targetHero));

            logicTree.EndSequence();
            yield return null;

        }
        

        private IEnumerator AttackHero(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var dealDamage = targetHero.HeroLogic.DealDamage;
            var attackPower = thisHero.HeroLogic.HeroAttributes.Attack;
            var criticalFactor = 0;

            
            logicTree.AddCurrent(AttackHeroAnimation(thisHero,targetHero));

            logicTree.AddCurrent(AttackTargetType.DealAttackDamageTest(dealDamage,thisHero, targetHero, attackPower, criticalFactor));

            logicTree.AddCurrent(AttackInterval(thisHero,targetHero));

            logicTree.EndSequence();
            yield return null;
        }


        private IEnumerator AttackHeroAnimation(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var visualTree = thisHero.CoroutineTreesAsset.MainVisualTree;

            visualTree.AddCurrent(AttackAnimation.StartAnimation(thisHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }



        private IEnumerator AttackInterval(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var visualTree = thisHero.CoroutineTreesAsset.MainVisualTree;
            
           //Inserts delay in seconds before calling visualTree.EndSequence()
            visualTree.AddCurrentWait(_intervalDelay, visualTree);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        


       







    }
}
