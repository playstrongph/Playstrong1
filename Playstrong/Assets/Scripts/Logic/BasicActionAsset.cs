using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class BasicActionAsset : ScriptableObject, IBasicActionAsset
    {
        //StartActions
        public virtual IEnumerator StartAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.HeroLivingStatus.ReceiveHeroAction(this, thisHero, targetHero);

            logicTree.EndSequence();
            yield return null;

        }
        
        public virtual IEnumerator StartAction(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: Implement in HeroLivingStatus - IBasicActionAsset
            hero.HeroLogic.HeroLivingStatus.ReceiveHeroAction(this, hero);
            
            logicTree.EndSequence();
            yield return null;

        }
        
        public IEnumerator StartAction(IHero hero, float value)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: Implement in HeroLivingStatus - IBasicActionAsset
            hero.HeroLogic.HeroLivingStatus.ReceiveHeroAction(this, hero, value);
            
            logicTree.EndSequence();
            yield return null;

        } 
        
        
        

        //TargetActions
        public virtual IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }

        public virtual IEnumerator TargetAction(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }

        public virtual IEnumerator TargetAction(IHero hero, float value)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }
        
        //UndoTargetActions
        //Park Use of this for now
        public virtual IEnumerator UndoTargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }

        public virtual IEnumerator UndoTargetAction(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }

        public virtual IEnumerator UndoTargetAction(IHero hero, float value)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }
        
        protected List<IHero> ShuffleList(List<IHero> heroList)
        {
            var randomList = heroList;
            
            //Randomize the List
            for (int i = 0; i < randomList.Count; i++) 
            {
                var temp = randomList[i];
                int randomIndex = Random.Range(i, randomList.Count);
                randomList[i] = randomList[randomIndex];
                randomList[randomIndex] = temp;
            }

            return randomList;
        }
        
        protected List<IHeroStatusEffect> ShuffleStatusEffectsList(List<IHeroStatusEffect> statusEffectsList)
        {
            //Randomize the List
            for (int i = 0; i < statusEffectsList.Count; i++) 
            {
                var temp = statusEffectsList[i];
                int randomIndex = Random.Range(i, statusEffectsList.Count);
                statusEffectsList[i] = statusEffectsList[randomIndex];
                statusEffectsList[randomIndex] = temp;
            }

            return statusEffectsList;
        }
        
        

    }
}
