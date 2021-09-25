using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.AnimationSOscripts;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "AttackAdditionalRandomTargets", menuName = "SO's/SkillActions/AttackAdditionalRandomTargets")]
    
    public class AttackAdditionalRandomTargetsActionAsset : SkillActionAsset
    {
        [SerializeField] private int additionalTargetsCount = 0;
        
        
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
           Debug.Log("Attack Target and Random Enemy Heroes");
            
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

            //logicTree.AddCurrent(AttackHero(thisHero,targetHero));
            
            logicTree.AddCurrent(AttackEnemyHeroTargets(thisHero,targetHero));

            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator AttackEnemyHeroTargets(IHero thisHero, IHero targetHero)
        {
        
            
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

            var enemyTargets = GetAttackTargets(targetHero);

            foreach (var enemyHero in enemyTargets)
            {
                logicTree.AddCurrent(AttackHero(thisHero,enemyHero));
            }
            
            Debug.Log("Attack Multiple Enemies: " +enemyTargets.Count);

            logicTree.EndSequence();
            yield return null;
        }

        private List<IHero> GetAttackTargets(IHero targetHero)
        {
            var enemyLivingHeroes = targetHero.LivingHeroes.LivingHeroesList;
            
            var otherEnemyTargets = new List<IHero>();
            var enemyTargetsFinal = new List<IHero>();
            otherEnemyTargets.Clear();
            enemyTargetsFinal.Clear();

            foreach (var hero in enemyLivingHeroes)
            {
                otherEnemyTargets.Add(hero);
            }
            otherEnemyTargets.Remove(targetHero);

            //Get the smaller number between additional targets and other living heroes, to determine how many times we'll iterate
            var targetCount = Mathf.Min(additionalTargetsCount, otherEnemyTargets.Count);
            
            //add the target hero to the final enemies list
            enemyTargetsFinal.Add(targetHero);
            
            //Start iteration for other targets
            for (var i=0; i < targetCount; i++)
            {
                //get random target from otherEnemies
                var index = Random.Range(0, otherEnemyTargets.Count);
                var otherEnemy = otherEnemyTargets[index];
                
                //add the random target to the final list
                enemyTargetsFinal.Add(otherEnemy);
                
                //Remove selected enemy from the selection pool
                otherEnemyTargets.Remove(otherEnemy);
            }
            
            
            
            return enemyTargetsFinal;
        }



        private IEnumerator AttackHero(IHero thisHero, IHero targetHero)
        {
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
            visualTree.AddCurrentWait(_intervalDelay, visualTree);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        


       







    }
}
