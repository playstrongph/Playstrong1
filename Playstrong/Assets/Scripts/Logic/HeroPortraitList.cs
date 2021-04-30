using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class HeroPortraitList : MonoBehaviour, IHeroPortraitList
    {
        [SerializeField] private List<GameObject> _heroList = new List<GameObject>();
    
        public List<GameObject> HeroList => _heroList;

        [SerializeField] private Transform _heroPortraitTransform;
        public Transform HeroPortraitTransform => _heroPortraitTransform;
        

        public List<GameObject> GetList()
        {
            return HeroList;
        }

        public Transform GetTransform()
        {
            _heroPortraitTransform = this.transform;
            return _heroPortraitTransform;

        }


    }
}
