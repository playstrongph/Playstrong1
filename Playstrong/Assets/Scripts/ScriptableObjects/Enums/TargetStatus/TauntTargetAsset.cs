using System;
using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.Enums
{
    [CreateAssetMenu(fileName = "TauntTarget", menuName = "SO's/Scriptable Enums/TauntTarget")]
    public class TauntTargetAsset : ScriptableObject, ITauntTargetAsset, ITargetStatus
    {
        
        //Test
        public void AddToTargetList(IHero hero, List<IHero> enemyHeroes, List<IHero> enemyTauntHeroes,
            List<IHero> enemyStealthHeroes)
        {
            enemyTauntHeroes.Add(hero);
        }
    }
}
