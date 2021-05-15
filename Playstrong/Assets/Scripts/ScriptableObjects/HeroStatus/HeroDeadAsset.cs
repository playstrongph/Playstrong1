using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.HeroStatus
{
    [CreateAssetMenu(fileName = "HeroDead", menuName = "SO's/HeroStatus/HeroDead")]
    public class HeroDeadAsset : ScriptableObject, IHeroStatusAsset, IHeroDeadAsset
    {

        public void StatusAction(IHeroLogic heroLogic)
        {
            
        }

       
        public void InitializeTurnController(ITurnController turnController)
        {
        }


    }
}
