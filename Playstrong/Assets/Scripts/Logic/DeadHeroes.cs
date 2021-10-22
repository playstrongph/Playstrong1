using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class DeadHeroes : MonoBehaviour, IDeadHeroes
    {
        [SerializeField] private List<GameObject> _heroesList = new List<GameObject>();
        public List<GameObject> HeroesList => _heroesList;
        
        [SerializeField] private Transform _transform;
        public Transform Transform => _transform;
        
        public List<IHero> DeadHeroesList
        {
            get
            {
                var herolist = new List<IHero>();
                herolist.Clear();
                foreach (var heroObject in HeroesList)
                {
                    var hero = heroObject.GetComponent<IHero>();
                    herolist.Add(hero);
                }
                return herolist;
            }
        }


    }
}
