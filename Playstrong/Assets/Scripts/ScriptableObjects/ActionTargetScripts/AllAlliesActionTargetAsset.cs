using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargetScripts
{
    
    [CreateAssetMenu(fileName = "TargetAllAllies", menuName = "SO's/ActionTargets/TargetAllAllies")]
    public class AllAlliesActionTargetAsset : ActionTargetsAsset
    {
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            //Debug.Log("AllEnemies - thisHero,targetHero");
            //var allEnemies = targetHero.GetAllLivingAllyHeroes();

            var allAllies = thisHero.LivingHeroes.LivingHeroesList;
            
            //Randomize allAllies Order

            var heroTargets = new List<IHero>(ShuffleList(allAllies));
            
            return heroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero thisHero)
        {
            //Debug.Log("AllEnemies - targetHero");
            //var allEnemies = targetHero.GetAllLivingAllyHeroes();

            var allAllies = thisHero.LivingHeroes.LivingHeroesList;

            var heroTargets = new List<IHero>(ShuffleList(allAllies));
            
            return heroTargets;
        }
            
    }
}
