using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargets
{
    
    [CreateAssetMenu(fileName = "TargetAllEnemies", menuName = "SO's/ActionTargets/TargetAllEnemies")]
    public class AllEnemiesActionTargetAsset : ActionTargetsAsset
    {
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            Debug.Log("Get Hero Targets 2 args");

            var allEnemies = targetHero.GetAllLivingAllyHeroes();
            
            var allEnemies2 = thisHero.LivingHeroes.Player.OtherPlayer.LivingHeroes.LivingHeroesList;

            var heroTargets = new List<IHero>(allEnemies2);
            
            return heroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero targetHero)
        {
            Debug.Log("Get Hero Targets 1 arg");

            var allEnemies = targetHero.GetAllLivingAllyHeroes();

            var allEnemies2 = targetHero.LivingHeroes.Player.OtherPlayer.LivingHeroes.LivingHeroesList;

            var heroTargets = new List<IHero>(allEnemies);
            
            return heroTargets;
        }
            
    }
}
