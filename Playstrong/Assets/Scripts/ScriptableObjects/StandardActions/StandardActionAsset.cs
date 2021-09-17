using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
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
        private List<IBasicConditionAsset> OrBasicConditions
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
        private List<IBasicConditionAsset> AndBasicConditions
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
        private List<IBasicActionAsset> BasicActions
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

    
        private int _finalAndConditions = 1;
        private int _finalOrConditions = 0;
        
        /// <summary>
        /// Passive Skills and "passive" component in Active Skills
        /// </summary>
        public IEnumerator RegisterStandardAction(IHero hero)
        {
            Debug.Log("Standard Action Register Hero");
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            StandardEvent.SubscribeStandardAction(hero,this);
            
            logicTree.EndSequence();
            yield return null;
        }
        public IEnumerator UnregisterStandardAction(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            StandardEvent.UnsubscribeStandardAction(hero,this);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// EDragSkillTarget - Basic Skills, Active Skills, and some Passive Skills
        /// </summary>
        public IEnumerator RegisterStandardAction(ISkill skill)
        {
            Debug.Log("Standard Action Register Skill");
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            StandardEvent.SubscribeStandardAction(skill,this);
            
            logicTree.EndSequence();
            yield return null;
        }
        public IEnumerator UnregisterStandardAction(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            StandardEvent.UnsubscribeStandardAction(skill,this);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Method subscribed to 1 arg events (hero)
        /// </summary>
        public void StartAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            foreach (var newTargetHero in ActionTargets.GetHeroTargets(targetHero))
            {
                if (FinalConditionValue(targetHero) > 0)
                {
                    foreach (var basicAction in BasicActions)
                        logicTree.AddCurrent(basicAction.StartAction(newTargetHero));
                }
            }
        }
        
        //Used by status effects
        public void StartAction(IHero targetHero,float value)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            foreach (var newTargetHero in ActionTargets.GetHeroTargets(targetHero))
            {
                if (FinalConditionValue(targetHero) > 0)
                {
                    foreach (var basicAction in BasicActions)
                        logicTree.AddCurrent(basicAction.StartAction(newTargetHero,value));
                }
            }
        }
        
        
        
        
        private int FinalConditionValue(IHero targetHero)
        {
            var finalCondition = FinalAndBasicCondition(targetHero) * FinalOrBasicCondition(targetHero);
            return finalCondition;
        }
        private int FinalAndBasicCondition(IHero targetHero)
        {
            //No Conditions, return 1
            if (AndBasicConditions.Count <= 0)
                return _finalAndConditions = 1;
            
            if(AndBasicConditions.Count>1)
            {
                foreach (var basicCondition in AndBasicConditions)
                {
                    _finalAndConditions *= basicCondition.GetValue(targetHero);
                }
               
            }
            return _finalAndConditions;
        }
        private int FinalOrBasicCondition(IHero targetHero)
        {
            //No Conditions, return 1
            if (OrBasicConditions.Count <= 0)
                return _finalOrConditions = 1;
            
            
            if(OrBasicConditions.Count>1)
            {
                foreach (var basicCondition in AndBasicConditions)
                {
                    _finalOrConditions += basicCondition.GetValue(targetHero);
                }
               
            }
            return _finalOrConditions;
        }


        /// <summary>
        /// Method subscribed to 2 arg events (thisHero, targetHero)
        /// </summary>
        public void StartAction(IHero thisHero, IHero targetHero)
        {   
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            foreach (var newTargetHero in ActionTargets.GetHeroTargets(thisHero,targetHero))
            {
                Debug.Log("Final Condition Value " +FinalConditionValue(thisHero, targetHero));
                if (FinalConditionValue(thisHero, targetHero) > 0)
                {
                    foreach (var basicAction in BasicActions)
                        logicTree.AddCurrent(basicAction.StartAction(thisHero,newTargetHero));
                }
            }
        }
        
        private int FinalConditionValue(IHero thisHero, IHero targetHero)
        {
            var finalCondition = FinalAndBasicCondition(thisHero,targetHero) * FinalOrBasicCondition(thisHero,targetHero);
            return finalCondition;
        }
        private int FinalAndBasicCondition(IHero thisHero, IHero targetHero)
        {
            //No Conditions, return 1
            if (AndBasicConditions.Count <= 0)
                return _finalAndConditions = 1;
            
            if(AndBasicConditions.Count>1)
            {
                foreach (var basicCondition in AndBasicConditions)
                {
                    _finalAndConditions *= basicCondition.GetValue(thisHero,targetHero);
                }
               
            }
            return _finalAndConditions;
        }
        private int FinalOrBasicCondition(IHero thisHero, IHero targetHero)
        {
            //No Conditions, return 1
            if (OrBasicConditions.Count <= 0)
                return _finalOrConditions = 1;
            
            
            if(OrBasicConditions.Count>1)
            {
                foreach (var basicCondition in AndBasicConditions)
                {
                    _finalOrConditions += basicCondition.GetValue(thisHero,targetHero);
                }
               
            }
            return _finalOrConditions;
        }


    }

    
}
