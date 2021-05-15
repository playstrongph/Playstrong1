using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.HeroStatus
{
    [CreateAssetMenu(fileName = "HeroInactive", menuName = "SO's/HeroStatus/HeroInactive")]
    public class HeroInactiveAsset : ScriptableObject, IHeroStatusAsset, IHeroInactiveAsset
    {

        public void StatusAction(IHeroLogic heroLogic)
        {
            
        }


        public void InitializeTurnController(ITurnController turnController)
        {
        }


    }
}
