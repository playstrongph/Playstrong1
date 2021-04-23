using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public interface IInitializePlayerHeroes
    {
        IEnumerator InitializeHeroes(ITeamHeroesAsset teamHeroesAsset, GameObject heroObjectPrefab, Transform boardLocation, ICoroutineTree tree);
    }
}