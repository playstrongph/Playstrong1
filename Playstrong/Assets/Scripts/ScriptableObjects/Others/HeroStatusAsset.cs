using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.Others
{
    [CreateAssetMenu(fileName = "Hero Status", menuName = "SO's/Hero Status")]
    public class HeroStatusAsset : ScriptableObject, IHeroStatusAsset
    {
        public void InitializeTurnController(ITurnController turnController)
        {
            
        }

        public void StatusAction(IHeroLogic heroLogic)
        {
            
        }


    }
}
