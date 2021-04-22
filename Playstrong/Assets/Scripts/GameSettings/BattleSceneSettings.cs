using Interfaces;
using UnityEngine;
using Utilities;

namespace GameSettings
{
    public class BattleSceneSettings : MonoBehaviour, IBattleSceneSettings
    {
        [SerializeField] [RequireInterface(typeof(IBranchLogic))]
        private Object _branchLogic;
        public IBranchLogic BranchLogic => _branchLogic as IBranchLogic;
        
        [SerializeField] private GameObject _heroObjectPrefab;
        public GameObject HeroObjectPrefab => _heroObjectPrefab;

        [SerializeField] private GameObject _skillObjectPrefab;
        public GameObject SkillObjectPrefab => _skillObjectPrefab;
        [SerializeField]
        [RequireInterface(typeof(ITeamHeroesAsset))] private ScriptableObject _playerTeamHeroesAsset;
        public ITeamHeroesAsset PlayerTeamHeroesAsset => _playerTeamHeroesAsset as ITeamHeroesAsset;
        
        [SerializeField]
        [RequireInterface(typeof(ITeamHeroesAsset))] private ScriptableObject _enemyTeamHeroesAsset;
        public ITeamHeroesAsset EnemyTeamHeroesAsset => _enemyTeamHeroesAsset as ITeamHeroesAsset;





    }
}
