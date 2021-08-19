using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.Actions.BaseClassScripts
{

    public class SkillActionAsset : ScriptableObject, IHeroAction
    {

        protected IHero ThisHero;
        protected IHero TargetHero;

        protected ICoroutineTree LogicTree;
        protected ICoroutineTree VisualTree;
        
        public virtual IEnumerator StartAction(IHero thisHero, IHero targetHero)
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
        public virtual IEnumerator StartAction(IHero targetHero, float value)
        {
            LogicTree.EndSequence();
            yield return null;
        }
        
        public virtual IEnumerator ActionTarget(IHero targetHero, float value)
        {
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
