using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.StandardActions
{
    public interface IStandardActionAsset
    {
        
               
        
        IEnumerator RegisterStandardAction(IHero hero);
        IEnumerator UnregisterStandardAction(IHero hero);
        IEnumerator RegisterStandardAction(ISkill skill);
        IEnumerator UnregisterStandardAction(ISkill skill);
        
        //Start Action 
        void StartAction(IHero targetHero);
        void StartAction(IHero thisHero, IHero targetHero);
        
        
        //Undo Start Action
        void UndoStartAction(IHero targetHero);
        void UndoStartAction(IHero thisHero, IHero targetHero);
       
        
        //Action Targets
        IActionTargets EventSubscribers { get; set; }
        IActionTargets BasicActionTargets { get; set; }
        
        
        //Basic Conditions
        List<IBasicConditionAsset> OrBasicConditions { get; }
        List<ScriptableObject> OrBasicConditionsObjects { get; }
        List<IBasicConditionAsset> AndBasicConditions { get; }
        List<ScriptableObject> AndBasicConditionsObjects { get; }

    }
}