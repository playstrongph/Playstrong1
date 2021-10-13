using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.GameEvents;
using UnityEngine;
using UnityEngine.Rendering;

namespace ScriptableObjects.StandardActions
{
    [CreateAssetMenu(fileName = "NewStandardAction", menuName = "SO's/StandardActions/NewStandardAction")]
    public class StandardActionAsset : ScriptableObject, IStandardActionAsset
    {
        [Header("Game Event")]
        [SerializeField] private ScriptableObject standardEvent;
        private IStandardEvent StandardEvent => standardEvent as IStandardEvent;

        [Header("Basic Action Targets")]
        //TODO: This needs to be changed to component level
        [SerializeField] private ScriptableObject actionTargets;

        public IActionTargets BasicActionTargets
        {
            get => actionTargets as IActionTargets;
            set => actionTargets = value as ScriptableObject;
        }
        

        [Header("OR Conditions")]
        [SerializeField] private List<ScriptableObject> orBasicConditions;

        public List<ScriptableObject> OrBasicConditionsObjects => orBasicConditions;

        public List<IBasicConditionAsset> OrBasicConditions
        {
            get
            {
                var basicConditions = new List<IBasicConditionAsset>();
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

        public List<ScriptableObject> AndBasicConditionsObjects => andBasicConditions;
        
        public List<IBasicConditionAsset> AndBasicConditions
        {
            get
            {
                var basicConditions = new List<IBasicConditionAsset>();
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

        private int _finalAndConditions;
        private int _finalOrConditions;
        //Test
        private IHeroStatusEffect _heroStatusEffect;
      
        
        
        //Event Based StandardAction
        public IEnumerator RegisterStandardAction(IHero hero)
        {
            //Debug.Log("Standard Action Register 1 Hero arg");
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            StandardEvent.SubscribeStandardAction(hero,this);
            
            logicTree.EndSequence();
            yield return null;
        }
        public IEnumerator RegisterStandardAction(ISkill skill)
        {
            
            //Debug.Log("Standard Action Register 1 Skill arg");
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            StandardEvent.SubscribeStandardAction(skill,this);
            
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
        public IEnumerator UnregisterStandardAction(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            StandardEvent.UnsubscribeStandardAction(skill,this);
            
            logicTree.EndSequence();
            yield return null;
        }
       
        
       
        public void StartAction(IHero targetHero)
        {
            //Debug.Log("Standard Action StartAction 1 Hero arg");
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: GetHeroTargets with _heroStatusEffect signature GetHeroTargets(targetHero,_heroStatusEffect)
            foreach (var newTargetHero in BasicActionTargets.GetHeroTargets(targetHero))
            {
                if (FinalConditionValue(targetHero) > 0)
                {
                    foreach (var basicAction in BasicActions)
                        logicTree.AddCurrent(basicAction.StartAction(newTargetHero));
                }
            }
        }
        public void StartAction(IHero thisHero, IHero targetHero)
        {   
            //Debug.Log("Standard Action StartAction 2 Heroes arg");
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            foreach (var newTargetHero in BasicActionTargets.GetHeroTargets(thisHero,targetHero))
            {
                //Debug.Log("Final Condition Value " +FinalConditionValue(thisHero, targetHero));
                if (FinalConditionValue(thisHero, targetHero) > 0)
                {
                    foreach (var basicAction in BasicActions)
                        logicTree.AddCurrent(basicAction.StartAction(thisHero,newTargetHero));
                }
            }
        }

        public void UndoStartAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            foreach (var newTargetHero in BasicActionTargets.GetHeroTargets(targetHero))
            {
                if (FinalConditionValue(targetHero) > 0)
                {
                    foreach (var basicAction in BasicActions)
                        logicTree.AddCurrent(basicAction.UndoTargetAction(newTargetHero));
                }
            }
        }
        public void UndoStartAction(IHero thisHero, IHero targetHero)
        {   
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            foreach (var newTargetHero in BasicActionTargets.GetHeroTargets(thisHero,targetHero))
            {
                //Debug.Log("Final Condition Value " +FinalConditionValue(thisHero, targetHero));
                if (FinalConditionValue(thisHero, targetHero) > 0)
                {
                    foreach (var basicAction in BasicActions)
                        logicTree.AddCurrent(basicAction.UndoTargetAction(thisHero,newTargetHero));
                }
            }
        }



        //FINAL CONDITION CALCULATIONS
        private int FinalConditionValue(IHero targetHero)
        {
            //Debug.Log("Final AndValue: " +FinalAndBasicCondition(targetHero) + " Final OrValue: "  +FinalOrBasicCondition(targetHero));
            
            var finalCondition = FinalAndBasicCondition(targetHero) * FinalOrBasicCondition(targetHero);
            Debug.Log("Final Condition Value: " +finalCondition);
            return finalCondition;
        }
        private int FinalAndBasicCondition(IHero targetHero)
        {
            Debug.Log("AndCondition Objects Count: " +AndBasicConditionsObjects.Count);
            //No Conditions, return 1
            if (AndBasicConditions.Count <= 0)
            {
                _finalAndConditions = 1;
                //Debug.Log("AndBasicConditions Count: " +AndBasicConditions.Count +" return: " +_finalAndConditions);
                return _finalAndConditions = 1;    
            }

            
            
            if(AndBasicConditions.Count>0)
            {
                //Default 1 for And
                _finalAndConditions = 1;
                foreach (var basicCondition in AndBasicConditions)
                {
                    //TODO: Check why this is multiplied
                    _finalAndConditions *= basicCondition.GetValue(targetHero);
                    _finalAndConditions = Mathf.Clamp(_finalAndConditions, 0, 1);
                    Debug.Log("AndBasicConditions Count: " +AndBasicConditions.Count +" return: " +_finalAndConditions);
                    //TODO: Clamp to 0,1
                }
               
            }
            
            Debug.Log("FinalAndCondition Value: " +_finalAndConditions);
            return _finalAndConditions;
        }
        private int FinalOrBasicCondition(IHero targetHero)
        {
            Debug.Log("OrCondition Objects Count: " +OrBasicConditionsObjects.Count);
            //No Conditions, return 1
            if (OrBasicConditions.Count <= 0)
            {
                _finalOrConditions = 1;
                //Debug.Log("OrBasicConditions Count: " +OrBasicConditions.Count +" return: " +_finalOrConditions);
                return _finalOrConditions = 1;  
                
            }

            if(OrBasicConditions.Count>0)
            {
                //Default 0 for OR
                _finalAndConditions = 0;
                foreach (var basicCondition in OrBasicConditions)
                {
                    _finalOrConditions += basicCondition.GetValue(targetHero);
                    _finalOrConditions = Mathf.Clamp(_finalOrConditions, 0, 1);
                    Debug.Log("OrBasicConditions Count: " +OrBasicConditions.Count +" return: " +_finalOrConditions);
                    //TODO: Clamp to 0,1
                }
               
            }
            
            Debug.Log("FinalOrCondition Value: " +_finalOrConditions);
            return _finalOrConditions;
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
                    //TODO: Need to make this generic
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
                    //TODO: Need to make this generic
                    _finalOrConditions += basicCondition.GetValue(thisHero,targetHero);
                }
            }
            return _finalOrConditions;
        }


    }

    
}
