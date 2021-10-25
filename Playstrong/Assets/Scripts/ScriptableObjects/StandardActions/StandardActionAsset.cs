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
    [CreateAssetMenu(fileName = "StandardAction", menuName = "SO's/StandardActions/StandardAction")]
    public class StandardActionAsset : ScriptableObject, IStandardActionAsset
    {

        [Header("Game Event")]
        [SerializeField] private ScriptableObject standardEvent;
        private IStandardEvent StandardEvent => standardEvent as IStandardEvent;
        
        
        [Header("Game Event Subscribers")]
        [SerializeField] private ScriptableObject eventSubscribers;

        public IActionTargets EventSubscribers
        {
            get => eventSubscribers as IActionTargets;
            set => eventSubscribers = value as ScriptableObject;
        }

        [Header("Basic Action Targets")]
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
        //private IHeroStatusEffect _heroStatusEffect;
      
        
        
        //Event Based StandardAction
        public IEnumerator RegisterStandardAction(IHero hero)
        {
            //Debug.Log("Standard Action Register 1 Hero arg");
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //StandardEvent.SubscribeStandardAction(hero,this);

            foreach (var subscriber in EventSubscribers.GetHeroTargets(hero))
            {
                StandardEvent.SubscribeStandardAction(subscriber,this);
            }

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
            
            //StandardEvent.UnsubscribeStandardAction(hero,this);
            
            foreach (var subscriber in EventSubscribers.GetHeroTargets(hero))
            {
                StandardEvent.UnsubscribeStandardAction(subscriber,this);
            }
            
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
       
        
       
        public virtual void StartAction(IHero targetHero)
        {
            //Debug.Log("" +this.name  +" StartAction targetHero");
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(StartActionCoroutine(targetHero));
        }
        
        protected IEnumerator StartActionCoroutine(IHero targetHero)
        {
            Debug.Log("" +this.name  +" StartAction targetHero");
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            
            foreach (var newTargetHero in BasicActionTargets.GetHeroTargets(targetHero))
            {
                if (FinalConditionValue(targetHero) > 0)
                {
                    foreach (var basicAction in BasicActions)
                        logicTree.AddCurrent(basicAction.StartAction(newTargetHero));
                }
            }
            
            logicTree.EndSequence();
            yield return null;
        }

        public virtual void StartAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //Has to be Coroutine to ensure GetHeroTargets are taken at the right time
            logicTree.AddCurrent(StartActionCoroutine(thisHero,targetHero));
        }
        
        //Has to be Coroutine to ensure GetHeroTargets are taken at the right time
        protected IEnumerator StartActionCoroutine(IHero thisHero, IHero targetHero)
        {   
            Debug.Log("" +this.name  +" StartAction thisHero,targetHero");
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            foreach (var newTargetHero in BasicActionTargets.GetHeroTargets(thisHero,targetHero))
            {
                
                if (FinalConditionValue(thisHero, targetHero) > 0)
                {
                    foreach (var basicAction in BasicActions)
                        logicTree.AddCurrent(basicAction.StartAction(thisHero,newTargetHero));
                }
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public void UndoStartAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
           logicTree.AddCurrent(UndoStartActionCoroutine(targetHero));
        }
        
        private IEnumerator UndoStartActionCoroutine(IHero targetHero)
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
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        public void UndoStartAction(IHero thisHero, IHero targetHero)
        {   
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
           logicTree.AddCurrent(UndoStartActionCoroutine(thisHero,targetHero));
        }
        
        
        private IEnumerator UndoStartActionCoroutine(IHero thisHero, IHero targetHero)
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
            
            logicTree.EndSequence();
            yield return null;
        }



        //FINAL CONDITION CALCULATIONS
        private int FinalConditionValue(IHero targetHero)
        {
            var finalCondition = FinalAndBasicCondition(targetHero) * FinalOrBasicCondition(targetHero);
            return finalCondition;
        }
        private int FinalAndBasicCondition(IHero targetHero)
        {
            
            if (AndBasicConditions.Count <= 0)
            {
                _finalAndConditions = 1;
                //Debug.Log("AndBasicConditions Count: " +AndBasicConditions.Count +" return: " +_finalAndConditions);
                return _finalAndConditions = 1;    
            }

            
            
            if(AndBasicConditions.Count>0)
            {
                _finalAndConditions = 1;
                foreach (var basicCondition in AndBasicConditions)
                {
                    
                    _finalAndConditions *= basicCondition.GetValue(targetHero);
                    _finalAndConditions = Mathf.Clamp(_finalAndConditions, 0, 1);
                    //Debug.Log("AndBasicConditions Count: " +AndBasicConditions.Count +" return: " +_finalAndConditions);
                    //TODO: Clamp to 0,1
                }
               
            }
            
            //Debug.Log("FinalAndCondition Value: " +_finalAndConditions);
            return _finalAndConditions;
        }
        private int FinalOrBasicCondition(IHero targetHero)
        {
            //Debug.Log("OrCondition Objects Count: " +OrBasicConditionsObjects.Count);
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
                    //Debug.Log("OrBasicConditions Count: " +OrBasicConditions.Count +" return: " +_finalOrConditions);
                    //TODO: Clamp to 0,1
                }
               
            }
            
            //Debug.Log("FinalOrCondition Value: " +_finalOrConditions);
            return _finalOrConditions;
        }
        private int FinalConditionValue(IHero thisHero, IHero targetHero)
        {
            var finalCondition = FinalAndBasicCondition(thisHero,targetHero) * FinalOrBasicCondition(thisHero,targetHero);
            return finalCondition;
        }
        private int FinalAndBasicCondition(IHero thisHero, IHero targetHero)
        {
            if (AndBasicConditions.Count <= 0)
            {
                _finalAndConditions = 1;
                //Debug.Log("AndBasicConditions Count: " +AndBasicConditions.Count +" return: " +_finalAndConditions);
                return _finalAndConditions = 1;    
            }

            
            
            if(AndBasicConditions.Count>0)
            {
                _finalAndConditions = 1;
                foreach (var basicCondition in AndBasicConditions)
                {
                    
                    _finalAndConditions *= basicCondition.GetValue(targetHero);
                    _finalAndConditions = Mathf.Clamp(_finalAndConditions, 0, 1);
                    //Debug.Log("AndBasicConditions Count: " +AndBasicConditions.Count +" return: " +_finalAndConditions);
                    //TODO: Clamp to 0,1
                }
               
            }
            
            //Debug.Log("FinalAndCondition Value: " +_finalAndConditions);
            return _finalAndConditions;
        }
        private int FinalOrBasicCondition(IHero thisHero, IHero targetHero)
        {
            //Debug.Log("OrCondition Objects Count: " +OrBasicConditionsObjects.Count);
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
                    //Debug.Log("OrBasicConditions Count: " +OrBasicConditions.Count +" return: " +_finalOrConditions);
                    //TODO: Clamp to 0,1
                }
               
            }
            
            //Debug.Log("FinalOrCondition Value: " +_finalOrConditions);
            return _finalOrConditions;
        }


    }

    
}
