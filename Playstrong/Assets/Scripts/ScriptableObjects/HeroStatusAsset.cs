using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;
using Utilities;

namespace ScriptableObjects
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
