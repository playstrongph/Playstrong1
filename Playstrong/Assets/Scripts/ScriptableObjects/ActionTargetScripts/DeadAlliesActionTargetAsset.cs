using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargetScripts
{
    
    [CreateAssetMenu(fileName = "DeadAllies", menuName = "SO's/ActionTargets/DeadAllies")]
    public class DeadAlliesActionTargetAsset : ActionTargetsAsset
    {
        [SerializeField] private int deadAlliesCount = 1;
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            var heroTargets = new List<IHero>();
            var deadAllies = thisHero.DeadHeroes.DeadHeroesList;
            var randomDeadAllies =  new List<IHero>(ShuffleList(deadAllies));
            
            //return lower number between actual deadAllies and number of dead ally targets
            var targetDeadAlliesCount = Mathf.Min(deadAlliesCount, randomDeadAllies.Count);
            

            for (int i = 0; i<targetDeadAlliesCount;i++)
            {
                heroTargets.Add(randomDeadAllies[i]);    
            }
            
            return heroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero thisHero)
        {
            var heroTargets = new List<IHero>();
            var deadAllies = thisHero.DeadHeroes.DeadHeroesList;
            var randomDeadAllies =  new List<IHero>(ShuffleList(deadAllies));
            
            //return lower number between actual deadAllies and number of dead ally targets
            var targetDeadAlliesCount = Mathf.Min(deadAlliesCount, randomDeadAllies.Count);
            

            for (int i = 0; i<targetDeadAlliesCount;i++)
            {
                heroTargets.Add(randomDeadAllies[i]);    
            }
            
            return heroTargets;
        }

        

    }
}
