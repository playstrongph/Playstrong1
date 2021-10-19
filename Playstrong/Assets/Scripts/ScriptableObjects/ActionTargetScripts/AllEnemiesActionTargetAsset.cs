using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargetScripts
{
    
    [CreateAssetMenu(fileName = "TargetAllEnemies", menuName = "SO's/ActionTargets/TargetAllEnemies")]
    public class AllEnemiesActionTargetAsset : ActionTargetsAsset
    {
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            //Debug.Log("AllEnemies - thisHero,targetHero");
            //var allEnemies = targetHero.GetAllLivingAllyHeroes();
            
            var allEnemies = thisHero.LivingHeroes.Player.OtherPlayer.LivingHeroes.LivingHeroesList;

            var heroTargets = new List<IHero>(allEnemies);
            
            return heroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero thisHero)
        {
            //Debug.Log("AllEnemies - targetHero");
            //var allEnemies = targetHero.GetAllLivingAllyHeroes();

            var allEnemies = thisHero.LivingHeroes.Player.OtherPlayer.LivingHeroes.LivingHeroesList;

            var heroTargets = new List<IHero>(allEnemies);
            
            return heroTargets;
        }
            
    }
}
