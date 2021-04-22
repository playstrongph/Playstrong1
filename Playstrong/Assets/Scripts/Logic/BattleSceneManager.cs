using GameSettings;
using Interfaces;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class BattleSceneManager : MonoBehaviour
    {
        [SerializeField] [RequireInterface(typeof(IBattleSceneSettings))]
        private Object _battleSceneSettings;

        public IBattleSceneSettings BattleSceneSettings => _battleSceneSettings as IBattleSceneSettings;

        public ICoroutineTree LogicTree { get; set; }

        private void Awake()
        {
            LogicTree = BattleSceneSettings.BranchLogic.LogicTree;
            
        }
    }
}
