using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargetScripts
{
    
    [CreateAssetMenu(fileName = "TargetAndRandomEnemies", menuName = "SO's/ActionTargets/TargetAndRandomEnemies")]
    public class TargetEnemyAndRandomEnemiesActionTargetAsset : ActionTargetsAsset
    {

        [SerializeField] private int otherRandomEnemiesCount;
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {

            var otherRandomEnemies = new List<IHero>(ShuffleList(targetHero.GetAllOtherLivingAllyHeroes()));
            
            var otherEnemiesCount = Mathf.Min(otherRandomEnemiesCount, otherRandomEnemies.Count);
            var heroTargets = new List<IHero>();
            
            //Original Target
            heroTargets.Add(targetHero);
            
            //Additional Target Heroes
            for (int i = 0; i<otherEnemiesCount;i++)
            {
                heroTargets.Add(otherRandomEnemies[i]);    
            }

           

            return heroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero thisHero)
        {
            var otherRandomEnemies = ShuffleList(thisHero.GetAllOtherLivingAllyHeroes());
            var otherEnemiesCount = Mathf.Min(otherRandomEnemiesCount, otherRandomEnemies.Count);
            var heroTargets = new List<IHero>();

            for (int i = 0; i<otherEnemiesCount;i++)
            {
                heroTargets.Add(otherRandomEnemies[i]);    
            }

            heroTargets.Add(thisHero);

            return heroTargets;
        }
        
        
            
    }
}
