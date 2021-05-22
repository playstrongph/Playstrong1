using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class TargetStatus : MonoBehaviour, ITargetStatus
    {
        public void AddToTargetList(IHero hero, List<IHero> enemyHeroes, List<IHero> enemyTauntHeroes,
            List<IHero> enemyStealthHeroes)
        {
            
        }
    }
}
