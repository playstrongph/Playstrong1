using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.HeroLivingStatus
{
    //[CreateAssetMenu(fileName = "LivingStatus", menuName = "SO's/HeroLivingStatus/LivingStatus")]
    public class HeroLivingStatusAsset : ScriptableObject, IHeroLivingStatusAsset
    {

        public void ReceiveHeroAction(IHeroAction heroAction, IHero initiator, IHero recipient)
        {
            
        }

        public void DoHeroAction(IHeroAction heroAction, IHero recipient)
        {
            
        }




    }
}
