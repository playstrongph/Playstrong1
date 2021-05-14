using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class InitTurnController : MonoBehaviour, IInitTurnController
    {
        private IBattleSceneManager _battleSceneManager;
        private void Awake()
        {
            _battleSceneManager = GetComponent<IBattleSceneManager>();
            
        }
        
        public IEnumerator InitializeTurnController()
        {
            foreach (var heroGameObject in _battleSceneManager.MainPlayer.LivingHeroes.HeroesList)
            {
                var heroTimer = heroGameObject.GetComponent<IHero>().HeroLogic.HeroTimer;
                
                _battleSceneManager.TurnController.HeroTimers.Add(heroTimer as Object);
            }
            
            foreach (var heroGameObject in _battleSceneManager.EnemyPlayer.LivingHeroes.HeroesList)
            {
                var heroTimer = heroGameObject.GetComponent<IHero>().HeroLogic.HeroTimer;
                
                _battleSceneManager.TurnController.HeroTimers.Add(heroTimer as Object);
            }

            var logicTree = _battleSceneManager.GlobalTrees.MainLogicTree;
            
            yield return null;
            logicTree.EndSequence();
            
        }
        
        
        
    }
}
