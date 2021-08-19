using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.HeroLivingStatus
{
    public class LivingStatusAsset : ScriptableObject, IHeroLivingStatusAsset
    {
        /// <summary>
        /// If the target hero is alive, this will call the initiator's DoAction Method
        /// </summary>
        public virtual void ReceiveHeroAction(IHeroAction heroAction, IHero initiator, IHero recipient)
        {
            //initiator.HeroLogic.HeroLivingStatus.DoHeroAction(heroAction, initiator, recipient);
           
        }
        
        /// <summary>
        /// If the initiator hero is alive, this will call the initiator's TargetHero method
        /// </summary>
        public virtual void DoHeroAction(IHeroAction heroAction, IHero initiator, IHero recipient)
        {
            //var logicTree = recipient.CoroutineTreesAsset.MainLogicTree;
            //logicTree.AddCurrent(heroAction.ActionTarget(initiator, recipient));

        }
    }
}
