using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class StartBattle : MonoBehaviour, IStartBattle
    {
        private IBattleSceneManager _battleSceneManager;

        private void Awake()
        {
            _battleSceneManager = GetComponent<IBattleSceneManager>();
        }
        
        public IEnumerator BattleStart()
        {
            _battleSceneManager.TurnController.StartTurnTimer();

            var logicTree = _battleSceneManager.GlobalTrees.MainLogicTree;
            
            yield return null;
            logicTree.EndSequence();
        }
    }
}
