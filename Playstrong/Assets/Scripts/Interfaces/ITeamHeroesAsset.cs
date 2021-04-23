using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

namespace Interfaces
{
    public interface ITeamHeroesAsset
    {
        List<ScriptableObject> TeamHeroes();
    }
}