using Interfaces;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class BattleSceneManager : MonoBehaviour
    {
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

        private void Awake()
        {
            ///Initialize Coroutine Tree and Queue
            CoroutineQueue coroutineQueue = new CoroutineQueue();
            coroutineQueue.CoroutineRunner(this);
            CoroutineTree coroutineTree = new CoroutineTree();
            coroutineTree.CoroutineRunner(this);
        }

    }
}
