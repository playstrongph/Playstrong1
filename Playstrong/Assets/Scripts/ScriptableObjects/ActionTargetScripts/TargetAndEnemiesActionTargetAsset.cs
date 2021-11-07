using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargetScripts
{
    
    
    /// <summary>
    /// Used on conjunction with RandomizeOrderLiving allies - for consistent randomize hero list across
    /// multiple standard actions
    /// </summary>
    [CreateAssetMenu(fileName = "TargetAndEnemies", menuName = "SO's/ActionTargets/TargetAndEnemies")]
    public class TargetAndEnemiesActionTargetAsset : ActionTargetsAsset
    {

        [SerializeField] private int otherRandomEnemiesCount;
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {

            //var otherRandomEnemies = new List<IHero>(ShuffleList(targetHero.GetAllOtherLivingAllyHeroes()));
            
            //Randomization happened at ane earlier standardaction = RandomizeOrder
            var otherEnemies = new List<IHero>(targetHero.AllOtherAllyHeroes);
            
            var otherEnemiesCount = Mathf.Min(otherRandomEnemiesCount, otherEnemies.Count);
            
            var heroTargets = new List<IHero>();
            
            heroTargets.Add(targetHero);
            
            //Additional Target Heroes
            for (int i = 0; i<otherEnemiesCount;i++)
            {
                heroTargets.Add(otherEnemies[i]);    
            }

            return heroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero targetHero)
        {
            //var otherRandomEnemies = new List<IHero>(ShuffleList(targetHero.GetAllOtherLivingAllyHeroes()));
            
            var otherEnemies = new List<IHero>(targetHero.AllOtherAllyHeroes);
            
            var otherEnemiesCount = Mathf.Min(otherRandomEnemiesCount, otherEnemies.Count);
            
            var heroTargets = new List<IHero>();
            
            heroTargets.Add(targetHero);
            
            //Additional Target Heroes
            for (int i = 0; i<otherEnemiesCount;i++)
            {
                heroTargets.Add(otherEnemies[i]);    
            }

            return heroTargets;
        }
        
        
            
    }
}
