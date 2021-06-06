using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.Enums.TargetStatus
{
    [CreateAssetMenu(fileName = "StealthTarget", menuName = "SO's/Scriptable Enums/StealthTarget")]
    public class StealthTargetAsset : ScriptableObject, IStealthTargetAsset, ITargetStatus
    {
        public void AddToTargetList(IHero hero, List<IHero> enemyHeroes, List<IHero> enemyTauntHeroes,
            List<IHero> enemyStealthHeroes)
        {
            enemyStealthHeroes.Add(hero);
        }
    }
}
