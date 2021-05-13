using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public interface IInitializeHeroSkills
    {
        IEnumerator InitializeSkills(ITeamHeroesAsset teamHeroesAsset, GameObject skillPanelPrefab, GameObject skillObjectPrefab, Transform boardLocation, Transform skillPreviewLocation);
    }
}