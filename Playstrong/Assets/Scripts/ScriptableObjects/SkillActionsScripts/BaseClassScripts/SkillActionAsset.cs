using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts.BaseClassScripts
{

    public class SkillActionAsset : ScriptableObject, IHeroAction
    {

        protected IHero ThisHero;
        protected IHero TargetHero;

        protected ICoroutineTree LogicTree;
        protected ICoroutineTree VisualTree;
        
        //TODO:  In refactoring, use generic method StartAction(IHero thisHero, IHero targetHero, float value)

        public IEnumerator StartAction(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);

            targetHero.HeroLogic.HeroLivingStatus.ReceiveHeroAction(this, thisHero, targetHero);
            
            LogicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Should only be accessed by AliveLivingHero.DoHeroAction
        /// </summary>
        public virtual IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);
            
            LogicTree.EndSequence();
            yield return null;

        }
        
        /// <summary>
        /// StartAction for StatusEffects
        /// </summary>
        public IEnumerator StartAction(IHero targetHero, float value)
        {
            InitializeValues(targetHero, targetHero);

            targetHero.HeroLogic.HeroLivingStatus.ReceiveHeroAction(this, targetHero, value);
            
            LogicTree.EndSequence();
            yield return null;
        }
        
        public virtual IEnumerator ActionTarget(IHero targetHero, float value)
        {
            InitializeValues(targetHero, targetHero);
            
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
