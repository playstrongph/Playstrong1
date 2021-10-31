using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargetScripts
{
    
    [CreateAssetMenu(fileName = "OtherAllies", menuName = "SO's/ActionTargets/OtherAllies")]
    public class OtherAlliesActionTargetAsset : ActionTargetsAsset
    {
        [SerializeField] private int otherAlliesCount;
        
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            var allAllies = thisHero.LivingHeroes.LivingHeroesList;
            var otherAllies = new List<IHero>(ShuffleList(allAllies));
            var heroTargets = new List<IHero>();
            var allyCount = Mathf.Min(otherAllies.Count, otherAlliesCount);
            
            otherAllies.Remove(thisHero);
            for (int i = 0; i < allyCount; i++)
            {
                heroTargets.Add(otherAllies[i]);                
                Debug.Log("Other Ally " +otherAllies[i].HeroName);
            }
            
            return heroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero thisHero)
        {
            var allAllies = thisHero.LivingHeroes.LivingHeroesList;
            var otherAllies = new List<IHero>(ShuffleList(allAllies));
            var heroTargets = new List<IHero>();
            var allyCount = Mathf.Min(otherAllies.Count, otherAlliesCount);
            
            otherAllies.Remove(thisHero);
            for (int i = 0; i < allyCount; i++)
            {
                heroTargets.Add(otherAllies[i]);       
                Debug.Log("Other Ally " +otherAllies[i].HeroName);
            }
            
            return heroTargets;
        }
            
    }
}
