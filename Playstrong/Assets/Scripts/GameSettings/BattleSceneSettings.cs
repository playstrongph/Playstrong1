using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Utilities;

namespace GameSettings
{
    public class BattleSceneSettings : MonoBehaviour, IBattleSceneSettings
    {
        [Header("Script Components")]
        [SerializeField] [RequireInterface(typeof(IBranchLogic))]
        private Object _branchLogic;
        public IBranchLogic BranchLogic => _branchLogic as IBranchLogic;
        
        
        [Header("Prefabs")]
        [SerializeField] private GameObject _heroObjectPrefab;
        public GameObject HeroObjectPrefab => _heroObjectPrefab;

        [SerializeField] private GameObject _skillObjectPrefab;
        public GameObject SkillObjectPrefab => _skillObjectPrefab;

        [SerializeField] private GameObject _skillPanelPrefab;
        public GameObject SkillPanelPrefab => _skillPanelPrefab;

        [SerializeField] private GameObject _heroPortraitPrefab;
        public GameObject HeroPortraitPrefab => _heroPortraitPrefab;

        [Header("SO Assets")]
        [SerializeField]
        [RequireInterface(typeof(ITeamHeroesAsset))] private ScriptableObject _playerTeamHeroesAsset;
        public ITeamHeroesAsset PlayerTeamHeroesAsset => _playerTeamHeroesAsset as ITeamHeroesAsset;
        
        [SerializeField]
        [RequireInterface(typeof(ITeamHeroesAsset))] private ScriptableObject _enemyTeamHeroesAsset;
        public ITeamHeroesAsset EnemyTeamHeroesAsset => _enemyTeamHeroesAsset as ITeamHeroesAsset;
        
        [Header("Transforms")]
        [SerializeField]
        private Transform _allyHeroesBoardLocation;

        public Transform AllyHeroesBoardLocation => _allyHeroesBoardLocation;

        [SerializeField] 
        private Transform _enemyHeroesBoardLocation;

        public Transform EnemyHeroesBoardLocation => _enemyHeroesBoardLocation;

        [SerializeField] private Transform _mainHeroPortraitLocation;
        public Transform MainHeroPortraitLocation => _mainHeroPortraitLocation;

        [SerializeField] private Transform _panelPortraitLocation;
        public Transform PanelPortraitLocation => _panelPortraitLocation;
        
        
        

        [SerializeField] private Transform _allySkillsBoardLocaton;
        public Transform AllySkillsBoardLocation => _allySkillsBoardLocaton;

        [SerializeField] private Transform _enemySkillsBoardLocation;
        public Transform EnemySkillsBoardLocation => _enemySkillsBoardLocation;
        
        [SerializeField] private Transform _allyPanelSkillsLocation;
        public Transform AllyPanelSkillsLocation => _allyPanelSkillsLocation;
        
        [SerializeField] private Transform _enemyPanelSkillsLocation;
        public Transform EnemyPanelSkillsLocation => _enemyPanelSkillsLocation;
        

        [SerializeField] private List<Transform> _heroPreviewLocations;
        public List<Transform> HeroPreviewLocations => _heroPreviewLocations;
        
       
        
       





    }
}
