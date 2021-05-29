using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.Others
{
    [CreateAssetMenu(fileName = "New Team", menuName = "SO's/New Team Heroes")]
    public class TeamHeroesAsset : ScriptableObject, ITeamHeroesAsset
    {

        [SerializeField] [RequireInterface(typeof(IHeroAsset))]
        private List<ScriptableObject> _teamHeroesAsset = new List<ScriptableObject>();
        public IHeroAsset ListTeamHeroesAsset => _teamHeroesAsset as IHeroAsset;

        private List<ScriptableObject> _teamHeroes;

        public List<ScriptableObject> TeamHeroes()
        {
            _teamHeroes = _teamHeroesAsset; 
            return _teamHeroes;
        }


    }
}
