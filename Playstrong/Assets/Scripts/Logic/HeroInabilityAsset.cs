using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class HeroInabilityAsset : ScriptableObject, IHeroInabilityAsset
    {

        public virtual IEnumerator StatusAction(ITurnController turnController)
        {
            //With Inability - turnController.StartHeroNextTurn
            //No Inability - turnController.StartHeroTurn
            
            yield return null;
        }

    }
}
