using System;
using UnityEngine;

namespace Logic
{
    public class EndTurnButton : MonoBehaviour, IEndTurnButton
    {
        private IBattleSceneManager _battleSceneManager;
        
        private ITurnController _turnController;

        public ITurnController TurnController
        {
            set { _turnController = value; }
        }

        private void Awake()
        {
            _battleSceneManager = GetComponentInParent<IBattleSceneManager>();
        }

        public void EndTurn()
        {
            _battleSceneManager.TurnController.EndCombatTurn();
        }


    }
}
