using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Utilities;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Team", menuName = "SO's/New Team Heroes")]
    public class TeamHeroesAsset : ScriptableObject, ITeamHeroesAsset
    {

        [SerializeField] [RequireInterface(typeof(IHeroAsset))]
        private List<ScriptableObject> _teamHeroesAsset = new List<ScriptableObject>();
        public IHeroAsset ListTeamHeroesAsset => _teamHeroesAsset as IHeroAsset;


    }
}
