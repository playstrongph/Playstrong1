using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Logic
{
    public class SortHeroesByEnergy : MonoBehaviour, ISortHeroesByEnergy
    {
        private ITurnController _turnController;

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }


        public IEnumerator SortByEnergy()
        {
            var activeHeroes = _turnController.ActiveHeroes;
            var logicTree = _turnController.GlobalTrees.MainLogicTree;

            //TODO: ShuffleHeroes first in case of a tie
            ShuffleList(_turnController.ActiveHeroes).Sort(CompareListByATB);

            yield return null;
            logicTree.EndSequence(); 
        }

        private int CompareListByATB(Object i1, Object i2)
        {
            var ix1 = i1 as IHeroTimer;
            var ix2 = i2 as IHeroTimer;
            
            var x = ix1.TimerValue.CompareTo(ix2.TimerValue);
            return x;
        }
        
        private List<Object> ShuffleList(List<Object> heroList)
        {
            var randomList = heroList;
            
            //Randomize the List
            for (int i = 0; i < randomList.Count; i++) 
            {
                var temp = randomList[i];
                int randomIndex = Random.Range(i, randomList.Count);
                randomList[i] = randomList[randomIndex];
                randomList[randomIndex] = temp;
            }

            return randomList;
        }
        
        
        
    
    }
}
