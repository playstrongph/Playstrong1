using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class SortHeroesByEnergy : MonoBehaviour, ISortHeroesByEnergy
    {

        private ITurnController _turnController;
        

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }

        public IEnumerator SortActiveHeroesByEnergy()
        {
            var returnList = new List<IHeroTimer>();
            var activeHeroes = _turnController.ActiveHeroes;
            var logicTree = _turnController.GlobalTrees.MainLogicTree;

            foreach (var activeHero in activeHeroes)
            {
                returnList.Add(activeHero as IHeroTimer);
            }
            
            returnList.Sort(CompareListByEnergy);

            yield return returnList;
            logicTree.EndSequence(); 
        }
        
        private int CompareListByEnergy(IHeroTimer i1, IHeroTimer i2)
        {
            var x = i1.TimerValue.CompareTo(i2.TimerValue);
            return x;
        }
        
        
        
    }
}
