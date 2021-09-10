using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
   public class StandardConditionAsset : ScriptableObject
   {
      [SerializeField] private List<ScriptableObject> andBasicConditions = new List<ScriptableObject>();

      private List<IBasicConditionAsset> AndBasicConditions
      {
         get
         {
            var basicConditions = new List<IBasicConditionAsset>();
            basicConditions.Clear();
         
            foreach (var andBasicConditionObject in andBasicConditions)
            {
               var andBasicCondition = andBasicConditionObject as IBasicConditionAsset;
               basicConditions.Add(andBasicCondition);
            }

            return basicConditions;
         }
      }
   
      [SerializeField] private List<ScriptableObject> orBasicConditions = new List<ScriptableObject>();

      private List<IBasicConditionAsset> OrBasicConditions
      {
         get
         {
            var basicConditions = new List<IBasicConditionAsset>();
            basicConditions.Clear();
         
            foreach (var orBasicConditionObject in orBasicConditions)
            {
               var orBasicCondition = orBasicConditionObject as IBasicConditionAsset;
               basicConditions.Add(orBasicCondition);
            }

            return basicConditions;
         }
      }
   
    
      [SerializeField] private List<ScriptableObject> basicActions = new List<ScriptableObject>();

      private List<IBasicActionAsset> BasicActions
      {
         get
         {
            var newBasicActions = new List<IBasicActionAsset>();
            newBasicActions.Clear();
         
            foreach (var basicActionObject in basicActions)
            {
               var basicAction = basicActionObject as IBasicActionAsset;
               newBasicActions.Add(basicAction);
            }

            return newBasicActions;
         }
      }

      public IEnumerator StartAction(IHero hero)
      {
         var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
         var finalCondition = ComputeFinalCondition(hero);

         if (finalCondition >= 1)
         {
            foreach (var basicAction in BasicActions)
            {
               logicTree.AddCurrent(basicAction.StartAction(hero));
            }
         }
         
         logicTree.EndSequence();
         yield return null;

      }
      
      private int ComputeFinalCondition(IHero hero)
      {
         //If no And conditions, value is equal to 1
         var andConditionTotal = 1;
         
         foreach (var basicCondition in AndBasicConditions)
         {
            andConditionTotal *= basicCondition.GetValue(hero);
         }

        
         var orConditionTotal = 0;
         //if no Or conditions, set value equal to 1
         if (OrBasicConditions.Count <= 0)
            orConditionTotal = 1;
         
         foreach (var basicCondition in OrBasicConditions)
         {
            orConditionTotal += basicCondition.GetValue(hero);
         }

         //if no OR or And Conditions, finalCondition = 1
         var finalCondition = orConditionTotal*andConditionTotal;

         return finalCondition;
      }
      
      public IEnumerator StartAction(IHero thisHero, IHero targetHero)
      {
         var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
         var finalCondition = ComputeFinalCondition(thisHero,targetHero);

         if (finalCondition >= 1)
         {
            foreach (var basicAction in BasicActions)
            {
               logicTree.AddCurrent(basicAction.StartAction(thisHero,targetHero));
            }
         }
         
         logicTree.EndSequence();
         yield return null;

      }
      
      private int ComputeFinalCondition(IHero thisHero, IHero targetHero)
      {
         //If no And conditions, value is equal to 1
         var andConditionTotal = 1;
         
         foreach (var basicCondition in AndBasicConditions)
         {
            andConditionTotal *= basicCondition.GetValue(thisHero,targetHero);
         }

        
         var orConditionTotal = 0;
         //if no Or conditions, set value equal to 1
         if (OrBasicConditions.Count <= 0)
            orConditionTotal = 1;
         
         foreach (var basicCondition in OrBasicConditions)
         {
            orConditionTotal += basicCondition.GetValue(thisHero,targetHero);
         }

         //if no OR or And Conditions, finalCondition = 1
         var finalCondition = orConditionTotal*andConditionTotal;

         return finalCondition;
      }
      public IEnumerator StartAction(IHero hero, float value)
      {
         var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
         var finalCondition = ComputeFinalCondition(hero,value);

         if (finalCondition >= 1)
         {
            foreach (var basicAction in BasicActions)
            {
               logicTree.AddCurrent(basicAction.StartAction(hero,value));
            }
         }
         
         logicTree.EndSequence();
         yield return null;

      }
      
      private int ComputeFinalCondition(IHero hero, float value)
      {
         //If no And conditions, value is equal to 1
         var andConditionTotal = 1;
         
         foreach (var basicCondition in AndBasicConditions)
         {
            andConditionTotal *= basicCondition.GetValue(hero,value);
         }

        
         var orConditionTotal = 0;
         //if no Or conditions, set value equal to 1
         if (OrBasicConditions.Count <= 0)
            orConditionTotal = 1;
         
         foreach (var basicCondition in OrBasicConditions)
         {
            orConditionTotal += basicCondition.GetValue(hero,value);
         }

         //if no OR or And Conditions, finalCondition = 1
         var finalCondition = orConditionTotal*andConditionTotal;

         return finalCondition;
      }

   }
}
