using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.GameEvents;
using UnityEngine;

namespace ScriptableObjects.StandardActions
{
    [CreateAssetMenu(fileName = "NewStandardAction", menuName = "SO's/StandardActions/NewStandardAction")]
    public class StandardActionAsset : ScriptableObject, IStandardActionAsset
    {
        [Header("Game Event")]
        [SerializeField] private ScriptableObject standardEvent;
        private IStandardEvent StandardEvent => standardEvent as IStandardEvent;

        [Header("Action Targets")]
        [SerializeField] private ScriptableObject actionTargets;
        private IActionTargets ActionTargets => actionTargets as IActionTargets;

        [Header("OR Conditions")]
        [SerializeField] private List<ScriptableObject> orBasicConditions;
        public List<IBasicConditionAsset> OrBasicConditions
        {
            get
            {
                var basicConditions = new List<IBasicConditionAsset>();
                basicConditions.Clear();
                foreach (var basicConditionObject in orBasicConditions)
                {
                    var basicCondition = basicConditionObject as IBasicConditionAsset;
                    basicConditions.Add(basicCondition);
                }
                return basicConditions;
            }
        }
        
        [Header("AND Conditions")]
        [SerializeField] private List<ScriptableObject> andBasicConditions;
        public List<IBasicConditionAsset> AndBasicConditions
        {
            get
            {
                var basicConditions = new List<IBasicConditionAsset>();
                basicConditions.Clear();
                foreach (var basicConditionObject in andBasicConditions)
                {
                    var basicCondition = basicConditionObject as IBasicConditionAsset;
                    basicConditions.Add(basicCondition);
                }
                return basicConditions;
            }
        }

        [Header("Basic Actions")]
        [SerializeField] private List<ScriptableObject> basicActions;
        public List<IBasicActionAsset> BasicActions
        {
            get
            {
                var newBasicActions = new List<IBasicActionAsset>();
                foreach (var basicActionObject in basicActions)
                {
                    var basicAction = basicActionObject as IBasicActionAsset;
                    newBasicActions.Add(basicAction);
                }

                return newBasicActions;
            }
        }

        
        /// <summary>
        /// Passive Skills and "passive" component in Active Skills
        /// </summary>
        public IEnumerator RegisterStandardAction(IHero hero)
        {
            yield return null;
        }
        
        /// <summary>
        /// EDragSkillTarget - Basic Skills, Active Skills, and some Passive Skills
        /// </summary>
        public IEnumerator RegisterStandardAction(ISKill skill)
        {
            yield return null;
        }
        
        /// <summary>
        /// Method subscribed to 1 arg events (hero)
        /// </summary>
        public void StartAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            foreach (var target in ActionTargets.GetHeroTargets(targetHero))
            {
                //if final Condition
                foreach (var basicAction in BasicActions)
                {
                    basicAction.StartAction(target);
                }
            }
            
        }
        
        /// <summary>
        /// Method subscribed to 2 arg events (thisHero, targetHero)
        /// </summary>
        public void StartAction(IHero thisHero, IHero targetHero)
        {   
            
            
        }



    }

    public interface ISKill
    {
    }
}
