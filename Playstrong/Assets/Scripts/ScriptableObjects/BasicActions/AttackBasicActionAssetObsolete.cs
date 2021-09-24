using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.AnimationSOscripts;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "AttackBasicActionObsolete", menuName = "SO's/BasicActions/AttackBasicActionObsolete")]
    
    public class AttackBasicActionAssetObsolete : BasicActionAsset
    {
        //Unique per skill
        [Header("Game Animation Asset")]
        [SerializeField] private ScriptableObject attackAnimation;
        private IGameAnimations AttackAnimation => attackAnimation as IGameAnimations;
        
        //Unique per skill
        [Header("Attack Target Type")] [SerializeField]
        private ScriptableObject attackTargetType;
        private IAttackTargetTypeAsset AttackTargetType => attackTargetType as IAttackTargetTypeAsset;

        [SerializeField]
        private float visualIntervalDelay = 0.7f;
        
        private int _finalAttackValue;
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(AttackHero(thisHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;

        }

        //This can be transferred to local SkillAttack
        private IEnumerator AttackHero(IHero thisHero, IHero targetHero)
        {
           Debug.Log("Basic Action Attack Hero");
            
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var dealDamage = targetHero.HeroLogic.DealDamage;
            var attackPower = thisHero.HeroLogic.HeroAttributes.Attack;
            var criticalFactor = 0;

            
            logicTree.AddCurrent(AttackHeroAnimation(thisHero,targetHero));

            logicTree.AddCurrent(AttackTargetType.DealAttackDamage(dealDamage,thisHero, targetHero, attackPower, criticalFactor));

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
            visualTree.AddCurrentWait(visualIntervalDelay, visualTree);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        


       







    }
}
