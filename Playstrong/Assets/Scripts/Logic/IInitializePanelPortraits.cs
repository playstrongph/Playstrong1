using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public interface IInitializePanelPortraits
    {
        IEnumerator InitializePortraits(ITeamHeroesAsset teamHeroesAsset, GameObject heroPortraitPrefab, Transform boardLocation);
    }
}