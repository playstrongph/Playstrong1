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
        public void AddHeroTarget(IHero hero, List<IHero> tauntList)
        {
            tauntList.Add(hero);
        }
    }
}
