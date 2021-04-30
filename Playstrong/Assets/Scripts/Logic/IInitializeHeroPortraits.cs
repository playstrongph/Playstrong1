using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public interface IInitializeHeroPortraits
    {
        IEnumerator InitializePortraits(ITeamHeroesAsset teamHeroesAsset, GameObject heroPortraitPrefab, Transform boardLocation, ICoroutineTree tree);
    }
}