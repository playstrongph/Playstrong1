﻿using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.Actions.BaseClassScripts
{

    public class SkillActionAsset : ScriptableObject, IHeroAction
    {

        protected IHero ThisHero;
        protected IHero TargetHero;

        protected ICoroutineTree LogicTree;
        protected ICoroutineTree VisualTree;
        
        public virtual IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);
            
            LogicTree.EndSequence();
            yield return null;

        }
        
        public virtual IEnumerator StartAction(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);

            targetHero.HeroLogic.HeroLivingStatus.ReceiveHeroAction(this, thisHero, targetHero);
            
            LogicTree.EndSequence();
            yield return null;
        }

        protected void InitializeValues(IHero thisHero, IHero targetHero)
        {
            ThisHero = thisHero;
            TargetHero = targetHero;

            LogicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            VisualTree = targetHero.CoroutineTreesAsset.MainVisualTree;
        }






    }
}