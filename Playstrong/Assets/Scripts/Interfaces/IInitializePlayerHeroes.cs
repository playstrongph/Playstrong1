using System.Collections;
using UnityEngine;

namespace Interfaces
{
    public interface IInitializePlayerHeroes
    {
        IEnumerator InitializeHeroes(ITeamHeroesAsset teamHeroesAsset, GameObject heroObjectPrefab, Transform boardLocation, ICoroutineTree tree);
    }
}