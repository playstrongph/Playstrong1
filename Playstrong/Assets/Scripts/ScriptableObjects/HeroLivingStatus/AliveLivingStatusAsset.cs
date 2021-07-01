using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.HeroLivingStatus
{
    [CreateAssetMenu(fileName = "AliveLivingStatus", menuName = "SO's/HeroLivingStatus/AliveLivingStatus")]
    public class AliveLivingStatusAsset : ScriptableObject, IHeroLivingStatusAsset
    {
        
        /// <summary>
        /// If the target hero is alive, this will call the initiator's DoAction Method
        /// </summary>
        public void ReceiveHeroAction(IHeroAction heroAction, IHero initiator, IHero recipient)
        {
            initiator.HeroLogic.HeroLivingStatus.DoHeroAction(heroAction, recipient);
           
        }
        
        /// <summary>
        /// If the initiator hero is alive, this will call the initiator's TargetHero method
        /// </summary>
        public void DoHeroAction(IHeroAction heroAction, IHero recipient)
        {
            var logicTree = recipient.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(heroAction.TargetHero(recipient));
            
           
        }




    }
}
