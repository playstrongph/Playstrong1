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
        void StartAction(IHero targetHero, float value);
        
        //Undo Start Action
        void UndoStartAction(IHero targetHero);
        void UndoStartAction(IHero thisHero, IHero targetHero);
        void UndoStartAction(IHero targetHero, float value);
        
        //Action Targets
        IActionTargets BasicActionTargets { get; set; }
        
        //Basic Conditions
        List<IBasicConditionAsset> OrBasicConditions { get; }
        List<ScriptableObject> OrBasicConditionsObjects { set; }
        List<IBasicConditionAsset> AndBasicConditions { get; }
        List<ScriptableObject> AndBasicConditionsObjects { set; }


        //TODO: Delete
        //Start Action On Event
        void StartActionOnEvent(IHero targetHero);
        void StartActionOnEvent(IHero targetHero, float value);
        void StartActionOnEvent(IHero thisHero, IHero targetHero);
        
       
                

    }
}