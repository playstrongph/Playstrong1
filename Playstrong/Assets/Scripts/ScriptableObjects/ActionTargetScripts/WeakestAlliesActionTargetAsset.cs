using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargetScripts
{
    
    [CreateAssetMenu(fileName = "WeakestAllies", menuName = "SO's/ActionTargets/WeakestAllies")]
    public class WeakestAlliesActionTargetAsset : ActionTargetsAsset
    {

        [SerializeField] private int weakestAlliesCount = 1;
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            var allAllies = thisHero.LivingHeroes.LivingHeroesList;
            var sortAllAllies = new List<IHero>(allAllies);
            
            //Sort allies by weakest to strongest
            sortAllAllies.Sort(SortByHealth);
            
            var heroTargets = new List<IHero>();

            for (int i = 0; i < weakestAlliesCount; i++)
            {
                heroTargets.Add(sortAllAllies[i]);
            }
            
            return heroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero thisHero)
        {
            var allAllies = thisHero.LivingHeroes.LivingHeroesList;
            var sortAllAllies = new List<IHero>(allAllies);
            
            //Sort allies by weakest to strongest
            sortAllAllies.Sort(SortByHealth);
            
            var heroTargets = new List<IHero>();

            for (int i = 0; i < weakestAlliesCount; i++)
            {
                heroTargets.Add(sortAllAllies[i]);
            }
            
            return heroTargets;
        }

        private int SortByHealth(IHero h1, IHero h2)
        {
            //Positive Sign: lowest to Highest?
            return h1.HeroLogic.HeroAttributes.Health.CompareTo(h2.HeroLogic.HeroAttributes.Health);
        }

    }
}
