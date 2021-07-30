using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

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

            _turnController.ActiveHeroes.Sort(CompareListByATB);
            
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
        
    
    }
}
