using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IInitializePlayerHeroes
    {
        IEnumerator InitializeHeroes(ITeamHeroesAsset teamHeroesAsset, GameObject heroObjectPrefab,
            Transform boardLocation, List<Transform> previewLocations, ICoroutineTree tree);
    }
}