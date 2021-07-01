using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.HeroLivingStatus
{
    [CreateAssetMenu(fileName = "DeadLivingStatus", menuName = "SO's/HeroLivingStatus/DeadLivingStatus")]
    public class DeadLivingStatusAsset : ScriptableObject, IHeroLivingStatusAsset
    {
        /// <summary>
        /// If the target hero is dead, Do Nothing
        /// </summary>
        public void ReceiveHeroAction(IHeroAction heroAction, IHero initiator, IHero recipient)
        {
            
        }
        
        /// <summary>
        /// If the initiator hero is dead, Do Nothing
        /// </summary>
        public void DoHeroAction(IHeroAction heroAction, IHero recipient)
        {
            
        }




    }
}
