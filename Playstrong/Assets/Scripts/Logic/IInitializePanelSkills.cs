using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public interface IInitializePanelSkills
    {
        IEnumerator InitializeSkills(ITeamHeroesAsset teamHeroesAsset, GameObject skillPanelPrefab, 
            GameObject skillObjectPrefab, Transform boardLocation, Transform skillPreviewLocation, ICoroutineTree tree);
    }
}