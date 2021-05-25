using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class EndHeroTurn : MonoBehaviour, IEndHeroTurn
    {
        private IHeroLogic _heroLogic;
        private ITurnController _turnController;

        private ICoroutineTree _logicTree;
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        
        }
        
        

        private void Start()
        {
            _turnController = _heroLogic.Hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            _logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
        }

        public IEnumerator EndTurn()
        {
            _turnController.EndTurn();

            yield return null;
            _logicTree.EndSequence();
        }


    }
}
