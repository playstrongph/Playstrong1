using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.Enums
{
    [CreateAssetMenu(fileName = "NormalTarget", menuName = "SO's/Scriptable Enums/NormalTarget")]
    public class NormalTargetAsset : ScriptableObject, INormalTargetAsset, ITargetStatus
    {

        public void AddToTargetList(IHero hero, List<IHero> enemyHeroes, List<IHero> enemyTauntHeroes, List<IHero> enemyStealthHeroes)
        {
            enemyHeroes.Add(hero);
        }



    }
}
