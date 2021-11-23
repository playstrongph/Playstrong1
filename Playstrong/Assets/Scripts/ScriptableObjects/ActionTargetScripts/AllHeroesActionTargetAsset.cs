using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargetScripts
{
    
    [CreateAssetMenu(fileName = "TargetAllHeroes", menuName = "SO's/ActionTargets/TargetAllHeroes")]
    public class AllHeroesActionTargetAsset : ActionTargetsAsset
    {
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            
            var heroTargets = new List<IHero>();
            var allAllies = thisHero.LivingHeroes.LivingHeroesList;
            var allEnemies = thisHero.LivingHeroes.Player.OtherPlayer.LivingHeroes.LivingHeroesList;

            foreach (var enemy in allEnemies)
            {
                heroTargets.Add(enemy);    
            }
            
            foreach (var ally in allAllies)
            {
                heroTargets.Add(ally);    
            }

            ShuffleList(heroTargets);
            
            return heroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero thisHero)
        {
            var heroTargets = new List<IHero>();
            var allAllies = thisHero.LivingHeroes.LivingHeroesList;
            var allEnemies = thisHero.LivingHeroes.Player.OtherPlayer.LivingHeroes.LivingHeroesList;

            foreach (var enemy in allEnemies)
            {
                heroTargets.Add(enemy);    
            }
            
            foreach (var ally in allAllies)
            {
                heroTargets.Add(ally);    
            }

            ShuffleList(heroTargets);
            
            return heroTargets;
        }
            
    }
}
