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

        [SerializeField] private Transform _transform;
        public Transform Transform => _transform;
        
        public List<GameObject> GetList()
        {
            return HeroList;
        }

        public Transform GetTransform()
        {
            _transform = this.transform;
            return _transform;
        }





    }
}
