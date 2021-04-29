using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class HeroesList : MonoBehaviour, IHeroesList
    {
        [SerializeField] private List<GameObject> _heroList = new List<GameObject>();
        public List<GameObject> HeroList => _heroList;

        
    }
}
